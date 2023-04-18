using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace TestModelNaiveBayes
{
    class Loaddata
    {

        public string[][] LoadData(string fn, int rows, int cols, char delimit)
        {

            string[][] result = MatrixString(rows, cols);
            FileStream ifs = new FileStream(fn, FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string[] tokens = null;
            string line = null;
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                tokens = line.Split(delimit);
                for (int j = 0; j < cols; ++j)
                    result[i][j] = tokens[j];
                ++i;
            }
            sr.Close(); ifs.Close();
            return result;
        }

        public string[][] MatrixString(int rows, int cols)
        {
            string[][] result = new string[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new string[cols];
            return result;
        }

    }
}
