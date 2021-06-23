using Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class RAFContext
    {
        private string fileName;
        private int size;

        public RAFContext(string fileName, int size)
        {
            this.fileName = fileName;
            this.size = size;
        }

        public Stream HeaderStream
        {
            get => File.Open($"{fileName}.hd", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public Stream DataStream
        {
            get => File.Open($"{fileName}.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public void Create<T>(T t)
        {
            using (BinaryWriter bwHeader = new BinaryWriter(HeaderStream),
                                  bwData = new BinaryWriter(DataStream))
            {
                int n, k;
                using (BinaryReader brHeader = new BinaryReader(bwHeader.BaseStream))
                {
                    if (brHeader.BaseStream.Length == 0)
                    {
                        n = 0;
                        k = 0;
                    }
                    else
                    {
                        brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                        n = brHeader.ReadInt32();
                        k = brHeader.ReadInt32();
                    }
                    //calculamos la posicion en Data
                    long pos = k * size;
                    bwData.BaseStream.Seek(pos,SeekOrigin.Begin);

                    PropertyInfo[] info = t.GetType().GetProperties();
                    foreach (PropertyInfo pinfo in info)
                    {
                        Type type = pinfo.PropertyType;
                        object obj = pinfo.GetValue(t, null);
                        
                        if (type.IsGenericType)
                        {
                            continue;
                        }

                        if (pinfo.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase))
                        {
                            bwData.Write(++k);
                            continue;
                        }

                        if (type == typeof(int))
                        {
                            bwData.Write((int)obj);
                        }
                        else if (type == typeof(long))
                        {
                            bwData.Write((long)obj);
                        }
                        else if (type == typeof(float))
                        {
                            bwData.Write((float)obj);
                        }
                        else if (type == typeof(double))
                        {
                            bwData.Write((double)obj);
                        }
                        else if (type == typeof(decimal))
                        {
                            bwData.Write((decimal)obj);
                        }
                        else if (type == typeof(char))
                        {
                            bwData.Write((char)obj);
                        }
                        else if (type == typeof(bool))
                        {
                            bwData.Write((bool)obj);
                        }
                        else if (type == typeof(string))
                        {
                            bwData.Write((string)obj);
                        }
                    }

                    long posh = 8 + n * 4;
                    bwHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                    bwHeader.Write(k);

                    bwHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                    bwHeader.Write(++n);
                    bwHeader.Write(k);
                }
            }
        }

        public T Get<T>(int id)
        {
            T newValue = (T)Activator.CreateInstance(typeof(T));
            using (BinaryReader brHeader = new BinaryReader(HeaderStream),
                                brData = new BinaryReader(DataStream))
            {
                brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                int n = brHeader.ReadInt32();
                int k = brHeader.ReadInt32();

                if (id <= 0 || id > k)
                {
                    return default(T);
                }

                PropertyInfo[] properties = newValue.GetType().GetProperties();
                long posh = 8 + (id - 1) * 4;
                //TODO Add Binary search to find the id
                brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                int index = brHeader.ReadInt32();
                //TO-DO VALIDATE INDEX
                long posd = (index - 1) * size;
                brData.BaseStream.Seek(posd, SeekOrigin.Begin);
                foreach (PropertyInfo pinfo in properties)
                {
                    Type type = pinfo.PropertyType;

                    if (type.IsGenericType)
                    {
                        continue;
                    }

                    if (type == typeof(int))
                    {
                        pinfo.SetValue(newValue, brData.GetValue<int>(TypeCode.Int32));
                    }
                    else if (type == typeof(long))
                    {
                        pinfo.SetValue(newValue, brData.GetValue<long>(TypeCode.Int64));
                    }
                    else if (type == typeof(float))
                    {
                        pinfo.SetValue(newValue, brData.GetValue<float>(TypeCode.Single));
                    }
                    else if (type == typeof(double))
                    {
                        pinfo.SetValue(newValue, brData.GetValue<double>(TypeCode.Double));
                    }
                    else if (type == typeof(decimal))
                    {
                        pinfo.SetValue(newValue, brData.GetValue<decimal>(TypeCode.Decimal));
                    }
                    else if (type == typeof(char))
                    {
                        pinfo.SetValue(newValue, brData.GetValue<char>(TypeCode.Char));
                    }
                    else if (type == typeof(bool))
                    {
                        pinfo.SetValue(newValue, brData.GetValue<bool>(TypeCode.Boolean));
                    }
                    else if (type == typeof(string))
                    {
                        pinfo.SetValue(newValue, brData.GetValue<string>(TypeCode.String));
                    }
                }

                return newValue;
            }

        }

        public List<T> GetAll<T>()
        {
            List<T> listT = new List<T>();
            int n, k;
            using (BinaryReader brHeader = new BinaryReader(HeaderStream))
            {
                brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                if (brHeader.BaseStream.Length== 0)
                {
                    return null;
                }
                n = brHeader.ReadInt32();
                k = brHeader.ReadInt32();
            }

            for (int i = 0; i < n; i++)
            {
                int index;
                using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                {
                    long posh = 8 + i * 4;
                    brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                    index = brHeader.ReadInt32();
                }

                T t = Get<T>(index);
                listT.Add(t);
            }

            return listT;
        }

        public List<T> Find<T>(Expression<Func<T, bool>> where)
        {
            List<T> listT = new List<T>();
            int n, k;
            Func<T,bool> comparator = where.Compile();
            using (BinaryReader brHeader = new BinaryReader(HeaderStream))
            {
                brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                n = brHeader.ReadInt32();
                k = brHeader.ReadInt32();
            }

            for (int i = 0; i < n; i++)
            {
                int index;
                using (BinaryReader brHeader = new BinaryReader(HeaderStream))
                {
                    long posh = 8 + i * 4;
                    brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);
                    index = brHeader.ReadInt32();
                }

                T t = Get<T>(index);
                if (comparator(t))
                {
                    listT.Add(t);
                }
                
            }
            return listT;
        }    

	// mi tucaso viene aca    
	/*Segun esta cosa que tengo 0 idea de como funciona, debe de eliminar pero del
         * header?, ya que mucho cuadreo borrarlo desde donde los guardamos asi que en simples
         * palabras solo eliminamos el ID?
        */
        public bool Delete<T>(T t)
        {
            using (BinaryWriter bwHeader = new BinaryWriter(HeaderStream))
            {
                using (BinaryReader brHeader = new BinaryReader(bwHeader.BaseStream))
                {
                    //Lista de enteros que no borraremos
                    List<int> IDs = new List<int>();
                    //posicionamos en el inicio
                    brHeader.BaseStream.Seek(0, SeekOrigin.Begin);

                    int n = brHeader.ReadInt32();
                    int k = brHeader.ReadInt32();
                    //Esto proporciona acceso a los meta datos, cremos un array para manipularlos
                    PropertyInfo[] properties = t.GetType().GetProperties();

                    //Obtenemos el id del objeto a eliminar
                    int id = getID(properties, t); 

                    for (int i = 0; i < n; i++)
                    {
                        long posh = 8 + i * 4;

                        brHeader.BaseStream.Seek(posh, SeekOrigin.Begin);

                        //obtenemos todos los ids
                        int allIds = brHeader.ReadInt32();

                        //Aqui la magia, se agregara el id que sea dif al que queremos borrar
                        if (allIds != id)
                        {
                            IDs.Add(allIds);
                        }
                    }

                    bwHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                    bwHeader.Write(--n); 
                    bwHeader.Write(k);

                    //Hace el mate de la idea principal,escribir los ids menos el que ibamos a borrar
                    foreach (int i in IDs)
                    {
                        bwHeader.Write(i);
                    }
                }
            }

            return true;
        }

	    private int getID<T>(PropertyInfo[] pInfos, T t)
            {
                foreach (PropertyInfo p in pInfos)
                {
                    Type type = p.PropertyType;

                    if (type.IsGenericType)
                    {
                        continue;
                    }
                    // si esto es igual a Id ignorando el formato ya sea mayusq o minusq
                    if (p.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase))
                    {
                        // cast porque devuelve un string y la funcion manda un entero
                        return Convert.ToInt32( p.GetValue(t, null));
                    }
                }
                //si un hace ningun matice se le manda 0
                return 0;
            }
	    public bool Update<T>(T t)
            {
                using (BinaryReader brHeader = new BinaryReader(HeaderStream), brData = new BinaryReader(DataStream))
                {
                    brHeader.BaseStream.Seek(0, SeekOrigin.Begin);
                    int n = brHeader.ReadInt32();

                    if (n == 0)
                        return false; // Solo si esta vacio

                    PropertyInfo[] properties = t.GetType().GetProperties(); // Para detectar los atributos y acceder a sus propiedades

                    //utilizar getID para encontrar el id a actualizar
                    int id = getID(properties, t);

                    // Si se localiza tiene que estar en el header
                    int position = SearchAlgorithms.randomBinarySearch(brHeader, id, 0, n - 1);

                    if (position < 0) // RandomBinarySearch devuelve -1 si dicho no valor no se encuentra
                        return false;
                    
                    int pD = (id - 1) * size;
                    brData.BaseStream.Seek(pD, SeekOrigin.Begin);

                    // y lo plasmamos como calcomania a escribir pa      
                    using (BinaryWriter bwData = new BinaryWriter(brData.BaseStream))
                    {
                        foreach (PropertyInfo pinfo in properties)
                        {
                            Type type = pinfo.PropertyType;
                            object obj = pinfo.GetValue(t, null);

                            if (type.IsGenericType)
                            {
                                continue;
                            }

                            if (pinfo.Name.Equals("Id", StringComparison.CurrentCultureIgnoreCase))
                            {
                                bwData.Write(id);
                                continue;
                            }

                            if (type == typeof(int))
                            {
                                bwData.Write((int)obj);
                            }
                            else if (type == typeof(long))
                            {
                                bwData.Write((long)obj);
                            }
                            else if (type == typeof(float))
                            {
                                bwData.Write((float)obj);
                            }
                            else if (type == typeof(double))
                            {
                                bwData.Write((double)obj);
                            }
                            else if (type == typeof(decimal))
                            {
                                bwData.Write((decimal)obj);
                            }
                            else if (type == typeof(char))
                            {
                                bwData.Write((char)obj);
                            }
                            else if (type == typeof(bool))
                            {
                                bwData.Write((bool)obj);
                            }
                            else if (type == typeof(string))
                            {
                                bwData.Write((string)obj);
                            }
                        }


                }
                }
                return true;
            }
        }
}
