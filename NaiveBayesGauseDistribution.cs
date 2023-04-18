
// 


using System;
using System.IO;

namespace NumericBayes
{
    class NumericBayesProgram
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

        static void Main(string[] args)


        {


            Console.WriteLine("\nBegin numeric naive Bayes demo");


     //      double[][] data = new double[29][];  // modified, better example

/*
            //Label 0: Iris-setosa
            data[0] = new double[] { 5.1,3.5,1.4,0.2, 0 };  // 0 = Iris-setosa
            data[1] = new double[] { 4.9,3.0,1.4,0.2, 0 };  // 0 = Iris-setosa
            data[2] = new double[] { 4.7,3.2,1.3,0.2, 0 };  // 0 = Iris-setosa
            data[3] = new double[] { 4.6,3.1,1.5,0.2, 0 };  // 0 = Iris-setosa
            data[4] = new double[] { 5.0,3.6,1.4,0.2, 0 };  // 0 = Iris-setosa
            data[5] = new double[] { 5.4,3.9,1.7,0.4, 0 };  // 0 = Iris-setosa
            data[6] = new double[] { 4.6,3.4,1.4,0.3, 0 }; // 0 = Iris-setosa
            data[7] = new double[] { 5.0,3.4,1.5,0.2, 0 }; // 0 = Iris-setosa
            data[8] = new double[] { 4.4,2.9,1.4,0.2, 0 }; // 0 = Iris-setosa
            data[9] = new double[] { 4.9,3.1,1.5,0.1, 0 }; // 0 = Iris-setosa
            data[10] = new double[] {5.4,3.7,1.5,0.2, 0 }; // 0 = Iris-setosa

            //Label 1: Iris-versicolor
            data[11] = new double[] { 7.0,3.2,4.7,1.4, 1 };  // 1 = Iris-versicolor
            data[12] = new double[] { 6.4,3.2,4.5,1.5, 1 };  // 1 = Iris-versicolor
            data[13] = new double[] { 6.9,3.1,4.9,1.5, 1 };  // 1 = Iris-versicolor
            data[14] = new double[] { 5.5,2.3,4.0,1.3, 1 };  // 1 = Iris-versicolor
            data[15] = new double[] { 6.5,2.8,4.6,1.5, 1 };  // 1 = Iris-versicolor
            data[16] = new double[] { 5.7,2.8,4.5,1.3, 1 };  // 1 = Iris-versicolor
            data[17] = new double[] { 6.3,3.3,4.7,1.6, 1 };  // 1 = Iris-versicolor
            data[18] = new double[] { 4.9,2.4,3.3,1.0, 1 };  // 1 = Iris-versicolor
            data[19] = new double[] { 6.6,2.9,4.6,1.3, 1 };  // 1 = Iris-versicolor
          
             //Label 2: Iris-virginica
            data[20] = new double[] { 6.3,3.3,6.0,2.5, 2 };  // 2 = Iris-virginica
            data[21] = new double[] { 5.8,2.7,5.1,1.9, 2 };  // 2 = Iris-virginica
            data[22] = new double[] { 7.1,3.0,5.9,2.1, 2 };  // 2 = Iris-virginica
            data[23] = new double[] { 6.3,2.9,5.6,1.8, 2 };  // 2 = Iris-virginica
            data[24] = new double[] { 6.5,3.0,5.8,2.2, 2 };  // 2 = Iris-virginica
            data[25] = new double[] { 7.6,3.0,6.6,2.1, 2 };  // 2 = Iris-virginica
            data[26] = new double[] { 4.9,2.5,4.5,1.7, 2 };  // 2 = Iris-virginica
            data[27] = new double[] { 7.3,2.9,6.3,1.8, 2 };  // 2 = Iris-virginica
            data[28] = new double[] { 6.7,2.5,5.8,1.8, 2 };  // 2 = Iris-virginica

            int N = data.Length;  // 29 items
            int N_class = 3;
            int N_feature = 4;
*/
           // Load Input Data
           string fn = "D:/Data/IrisDataTrainning.txt";
           int N_feature = 4;
           int N_class = 3;
           int N = 117;


           NumericBayesProgram p = new NumericBayesProgram();
            //  string[][] data = p.LoadData(fn, N, N_feature + 1, ',');

            string[][] data =  p.LoadData(fn, N, N_feature + 1, ',');

            Console.WriteLine(data);

            string fn_test = "D:/Data/IrisDataTesting.txt";
            int N_test = 33;
            string[][] data_test2 = p.LoadData(fn_test, N_test, N_feature + 1, ',');


            // 0. class counts

            // Read training Data
            Console.WriteLine(" Training Data: ");

            for (int i = 0; i < 50; ++i)
            {
                // Console.Write("[" + i + "] ");

                for (int j = 0; j < N_feature + 1; ++j)
                {
                    Console.WriteLine(data[i][j] + " ");
                }
                Console.WriteLine("......\n");
            }

            int[] classCts = new int[N_class];
            // Three type of flower


            for (int i = 0; i < N; ++i)
            {
                //int c = (int)data[i][N_feature];

                int c = int.Parse(data[i][N_feature]);
                ++classCts[c];
            }


            // Read Data Test Data
            Console.WriteLine(" Testing Data: ");


            for (int i = 0; i < 30; ++i)
            {
                // Console.Write("[" + i + "] ");

                for (int j = 0; j < N_feature + 1; ++j)
                {
                    Console.WriteLine(data[i][j] + " ");
                }
                Console.WriteLine("......\n");
            }

            int[] classCtstest = new int[N_class];
            // Three type of flower


            for (int i = 0; i < N_test; ++i)
            {
                //int c = (int)data[i][N_feature];

                int c = int.Parse(data[i][N_feature]);
                ++classCtstest[c];
            }



            // 1. compute means 



            double[][] means = new double[N_class][];  // [class][predictor]
            for (int c = 0; c < N_class; ++c)
                means[c] = new double[N_feature];

            for (int i = 0; i < N; ++i)
            {
                //int c = (int)data[i][N_feature];

                int c = int.Parse(data[i][N_feature]);

                for (int j = 0; j < N_feature; ++j)  // 4 features
                                                     // means[c][j] += data[i][j];
                    means[c][j] += double.Parse(data[i][j]);
            }

            for (int c = 0; c < N_class; ++c)
            {
                for (int j = 0; j < N_feature; ++j)
                    means[c][j] /= classCts[c];
            }

            // display means


            Console.WriteLine("\n Means of every features:");


            for (int c = 0; c < N_class; ++c)
            {
                Console.Write("class: " + c + "  ");
                for (int j = 0; j < N_feature; ++j)
                    Console.Write(means[c][j].ToString("F2").PadLeft(8) + " ");
                Console.WriteLine("");
            }



            double[][] variances = new double[N_class][];


            for (int c = 0; c < N_class; ++c)
                variances[c] = new double[N_feature];


            for (int i = 0; i < N; ++i)
            {
                //int c = (int)data[i][N_feature];

                int c = int.Parse(data[i][N_feature]);

                for (int j = 0; j < N_feature; ++j)
                {
                    double x = Double.Parse(data[i][j]);
                    double u = means[c][j];
                    variances[c][j] += (x - u) * (x - u);
                }
            }

            for (int c = 0; c < N_class; ++c)
            {
                for (int j = 0; j < N_feature; ++j)
                    variances[c][j] /= classCts[c] - 1;  // sample variance
            }

            // display variances


            Console.WriteLine("\n Variances of 4 feature ");
            //
            for (int c = 0; c < N_class; ++c)
            //
            {
                Console.Write("class: " + c + "  ");
                for (int j = 0; j < N_feature; ++j)
                    Console.Write(variances[c][j].ToString("F6").PadLeft(12));
                Console.WriteLine("");
            }

            //
            double[][] data_test = new double[31][];


            data_test[0] = new double[] { 5.1, 3.4, 1.5, 0.2 }; // 0 
            data_test[1] = new double[] { 5.0, 3.5, 1.3, 0.3 };  // 0 
            data_test[2] = new double[] { 4.5, 2.3, 1.3, 0.3 };  // 0
            data_test[3] = new double[] { 4.4, 3.2, 1.3, 0.2 };  // 0 
            data_test[4] = new double[] { 5.1, 3.8, 1.9, 0.4 };  // 0 
            data_test[5] = new double[] { 4.8, 3.0, 1.4, 0.38 };  // 0 

            data_test[6] = new double[] { 5.1, 3.8, 1.6, 0.2 }; // 0 
            data_test[7] = new double[] { 4.6, 3.2, 1.4, 0.2 };  // 0 
            data_test[8] = new double[] { 5.3, 3.7, 1.5, 0.2 };  // 0 
            data_test[9] = new double[] { 5.0, 3.3, 1.4, 0.2 };  // 0


            data_test[10] = new double[] { 5.5, 2.5, 4.0, 1.3 };  // 1 
            data_test[11] = new double[] { 5.5, 2.6, 4.4, 1.2 };  // 1 
            data_test[12] = new double[] { 6.1, 3.0, 4.6, 1.4 }; // 1 
            data_test[13] = new double[] { 5.8, 2.6, 4.0, 1.2 };  // 1 
            data_test[14] = new double[] { 5.0, 2.3, 3.3, 1.0 };  // 1 
            data_test[15] = new double[] { 5.7, 2.9, 4.2, 1.3 };  // 1 
            data_test[16] = new double[] { 6.2, 2.9, 4.3, 1.3 };  // 1
            data_test[17] = new double[] { 5.1, 2.5, 3.0, 1.1 };  // 1 
            data_test[18] = new double[] { 5.7, 2.8, 4.1, 1.3 }; // 1 

            data_test[19] = new double[] { 6.9, 3.1, 5.4, 2.1 };  // 2 
            data_test[20] = new double[] { 6.7, 3.1, 5.6, 2.4 };  // 2
            data_test[21] = new double[] { 6.9, 3.1, 5.1, 2.3 };  // 2
            data_test[22] = new double[] { 5.8, 2.7, 5.1, 1.9 };  // 2 
            data_test[23] = new double[] { 6.8, 3.2, 5.9, 2.3 };  // 2 
            data_test[24] = new double[] { 6.7, 3.3, 5.7, 2.5 };  // 2
            data_test[25] = new double[] { 6.7, 3.0, 5.2, 2.3 };  // 2 
            data_test[26] = new double[] { 6.3, 2.5, 5.0, 1.9 };  // 2 
            data_test[27] = new double[] { 6.5, 3.0, 5.2, 2.0 };  // 2
            data_test[28] = new double[] { 6.2, 3.4, 5.4, 2.3 };  // 2 
            data_test[29] = new double[] { 5.9, 3.0, 5.1, 1.8 };  // 2 
           
            // set up item to predict

/*
            double[] unk1 = data_test[0];
            double[] unk2 = data_test[1];
            double[] unk3 = data_test[2];
            double[] unk4 = data_test[3];
            double[] unk5 = data_test[4];
            double[] unk6 = data_test[5];*/


            /*
            Console.WriteLine("\n Item to predict:");
            Console.WriteLine(data_test[5]);
*/


            // Datatest 2


            // 3. conditional probabilities


            double[][] condProbs = new double[N_class][];
            for (int c = 0; c < N_class; ++c)
                condProbs[c] = new double[N_feature];

            for (int c = 0; c < N_class; ++c)  // each class

            {
                for (int j = 0; j < N_feature; ++j)  // each predictor
                {
                    double u = means[c][j];
                    double v = variances[c][j];

                   
                    double x = data_test[0][j];
                    condProbs[c][j] = ProbDensFunc(u, v, x);
                }
            }

            // display conditional probs

            Console.WriteLine("\n Conditional prob vals of 4 feature:");

            for (int c = 0; c < N_class; ++c)

            {
                Console.Write("class: " + c + "  ");

                for (int j = 0; j < N_feature; ++j)
                    Console.Write(condProbs[c][j].
                      ToString("F6").PadLeft(12));
                Console.WriteLine("");
            }

            // 4. unconditional prob of each class in the data


            double[] classProbs = new double[N_class];
            for (int c = 0; c < N_class; ++c)
                classProbs[c] = (classCts[c] * 1.0) / N;


            // display class probs

            Console.WriteLine("\n Unconditional class probabilities (0, 1, 2):");
            for (int c = 0; c < N_class; ++c)
                Console.WriteLine("class: " + c + "   " +
                  classProbs[c].ToString("F4"));


            // 5. compute evidence terms 


            //The evidence (also termed normalizing constant) may be calculated:

            double[] evidenceTerms = new double[N_class];  // one value per class


            for (int c = 0; c < N_class; ++c)
            {
                evidenceTerms[c] = classProbs[c];
                for (int j = 0; j < N_feature; ++j)
                    evidenceTerms[c] *= condProbs[c][j];
            }

            // display evidence terms

            Console.WriteLine("\nEvidence terms (class 0, class 1, class 2):");
            
            
            for (int c = 0; c < N_class; ++c)


                Console.WriteLine("class: " + c +
                  "   " + evidenceTerms[c].ToString("F6"));


            // 6. compute final prediction probs


            double sumEvidence = 0.0;

            for (int c = 0; c < N_class; ++c)


                sumEvidence += evidenceTerms[c];

            double[] predictProbs = new double[N_class];
            for (int c = 0; c < N_class; ++c)
                predictProbs[c] = evidenceTerms[c] / sumEvidence;

            // display prediction probabilities


            Console.WriteLine("\nPrediction probabilities (class 0, class 1, class 2):");

            for (int c = 0; c < N_class; ++c)
                Console.WriteLine("class: " + c +
                  "   " + predictProbs[c].ToString("F6"));

            Console.WriteLine("\nEnd demo");
            Console.ReadLine();
        
        } // Main 

       
        static double ProbDensFunc(double u, double v, double x)

        {
            double left = 1.0 / Math.Sqrt(2 * Math.PI * v);
            double right = Math.Exp(-(x - u) * (x - u) / (2 * v));
            return left * right;
        }

    } // Program class
} // ns

