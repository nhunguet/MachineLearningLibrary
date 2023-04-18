
// 


using System;
using System.IO;

namespace NumericBayes


{

    class NumericBayesProgram

    {

        public double[][] LoadData(string fn, int rows, int cols, char delimit) {

            double[][] result = MatrixString(rows, cols);
            FileStream ifs = new FileStream(fn, FileMode.Open);
            StreamReader sr = new StreamReader(ifs);
            string[] tokens = null;
            string line = null;d
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                tokens = line.Split(delimit);
                for (int j = 0; j < cols; ++j)
                    result[i][j] = tokens[i][j];
                ++i;
            }
            sr.Close(); ifs.Close();
            return result;
               
        }

        public double[][] MatrixString(int rows, int cols)
            {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
           }


        static void Main(string[] args)


        {


            
            Console.WriteLine("\nBegin numeric naive Bayes demo");
           
            
            // Load Input Data


           string fn = "D:/Data/IrisDatanumber.txt";
           int N_feature = 5;
           int N_class = 3;
           int N = 150;

           double[][] data = LoadData(fn, N , N_feature + 1, ',');
            // 0. class counts


            // Read training Data
            Console.WriteLine(" Training Data: ");

           for(int i = 0; i < 10; ++ i)
            { 
                Console.Write("[" + i + "] ");

                for (int j = 0; j < N_feature + 1; ++j)
                {
                    Console.WriteLine(data[i][j] + " ");
                }
                Console.WriteLine("......\n");
            }

          int[] classCts = new int[N_class];  // Three type of flower


            for (int i = 0; i < N; ++i)
            {
                int c = (int)data[i][N_feature];
                ++classCts[c];
            }



            // 1. compute means 



            double[][] means = new double[N_class][];  // [class][predictor]
            for (int c = 0; c < N_class; ++c)
                means[c] = new double[N_feature];

            for (int i = 0; i < N; ++i)
            {
                int c = (int)data[i][N_feature];
                for (int j = 0; j < N_feature; ++j)  // ht, wt, foot
                    means[c][j] += data[i][j];
            }

            for (int c = 0; c < N_class; ++c)
            {
                for (int j = 0; j < N_feature; ++j)
                    means[c][j] /= classCts[c];
            }

            // display means


            Console.WriteLine("\n Means of height, weight, foot:");


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
                int c = (int)data[i][N_feature];
                for (int j = 0; j < N_feature; ++j)
                {
                    double x = data[i][j];
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

            Console.WriteLine("\n Variances of height, weight, foot:");
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
            double[][] data_test = new double[6][];


            data_test[0] = new double[] {4.3,3.0,1.1,0.1 }; // 0 
            data_test[1] = new double[] {5.1,3.5,1.4,0.2 };  // 0 
            data_test[2] = new double[] {5.8,2.7,4.1,1.0 };  // 1 
            data_test[3] = new double[] {6.4,3.2,4.5,1.5 };  // 1 
            data_test[4] = new double[] {6.3,3.3,6.0,2.5 };  // 2 
            data_test[5] = new double[] {6.1,3.0,4.9,1.8 };  // 2 

            // set up item to predict

             double[] unk1 = data_test[0];
             double[] unk2 = data_test[1];
             double[] unk3 = data_test[2];
             double[] unk4 = data_test[3];
             double[] unk5 = data_test[4];
             double[] unk6 = data_test[5];


            Console.WriteLine("\n Item to predict:");
            Console.WriteLine(data_test[5]);
            
            

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
                      double x = unk5[j];
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

            Console.WriteLine("\nEvidence terms (male, female):");
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
            Console.WriteLine("\nPrediction probabilities (male, female):");

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

