using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    class SearchAlgorithms
    {

        public static int randomBinarySearch(BinaryReader br,int key,int low,int high)
        {
            int index = int.MinValue;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                long pos = 8 + (mid) * 4;
                br.BaseStream.Seek(pos,SeekOrigin.Current);
                int id = br.ReadInt32();
                if (id < key)
                {
                    low = mid + 1;
                }
                else if (id > key)
                {
                    high = mid - 1;
                }
                else if (id == key)
                {
                    index = (int)pos;
                    break;
                }
            }
            return index;
        }
    }
}
