using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningLibrary
{
    class Program
    {


        static void Main(string[] args)
        {
            string fn = "D:/Data/IrisDataTrainning.txt";

            int N_feature = 4;
            int N_class = 3;
            int N = 117;
            CommonClass p = new CommonClass();
            string[][] data_training = p.LoadData(fn, N, N_feature + 1, ',');
            //Cout 
            int[] classCts = new int[N_class];
            for (int i = 0; i < N; ++i)
            {

                int c = int.Parse(data_training[i][N_feature]);
                ++classCts[c];
            }
            Console.WriteLine(classCts[2]);
        }


    }
}
