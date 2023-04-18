//

//Bayes Naive Algorithm using C# to implement from Scratch 


using System;
using System.IO;
namespace CSharp


{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nBegin simple naive Bayes demo\n");
            
            // Load Input Data
            
            string fn = "D:/Learning C#/data2.txt";

            int nx = 4;  // Number predictor variables
            int nc = 2;  // Number classes
            int N = 14;  // Number data items


            string[][] data = LoadData(fn, N, nx + 1, ',');


            // Read Training Data

            

            Console.WriteLine("Training data:");
            
            for (int i = 0; i < 10; ++i)
            {
                Console.Write("[" + i + "] ");
                for (int j = 0; j < nx + 1; ++j)
                {
                    Console.Write(data[i][j] + " ");
                }
                Console.WriteLine("");
            }
            
            Console.WriteLine(". . . \n");


            int[][] jointCts = MatrixInt(nx, nc);
            int[] yCts = new int[nc];
            string[] X = new string[] { "Trẻ", "Trung Bình", "Có","Cao" };


            Console.WriteLine("Item to classify: ");


            
            for (int i = 0; i < nx; ++i)
                Console.Write(X[i] + " ");
            Console.WriteLine("\n");


            // Compute joint counts and y counts

            for (int i = 0; i < N; ++i)
            {
                int y = int.Parse(data[i][nx]);
                ++yCts[y];
                for (int j = 0; j < nx; ++j)
                {
                    if (data[i][j] == X[j])
                        ++jointCts[j][y];
                }
            }


            // Laplacian smoothing

            for (int i = 0; i < nx; ++i)
                for (int j = 0; j < nc; ++j)
                    ++jointCts[i][j];
            Console.WriteLine("Joint counts: ");
            
            
            for (int i = 0; i < nx; ++i)
            {
                for (int j = 0; j < nc; ++j)
                {
                    Console.Write(jointCts[i][j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n Class counts: ");
            
            
            for (int k = 0; k < nc; ++k)
                Console.Write(yCts[k] + " ");
            Console.WriteLine("\n");
            

            // Compute evidence terms
            
            
            double[] eTerms = new double[nc];
            for (int k = 0; k < nc; ++k)
            {
                double v = 1.0;
                for (int j = 0; j < nx; ++j)
                {
                    v *= (double)(jointCts[j][k]) / (yCts[k] + nx);
                }
                v *= (double)(yCts[k]) / N;
                eTerms[k] = v;
            }
            
            Console.WriteLine("Evidence terms:");
            for (int k = 0; k < nc; ++k)
                Console.Write(eTerms[k].ToString("F4") + " ");
            Console.WriteLine("\n");
            double evidence = 0.0;
            for (int k = 0; k < nc; ++k)
                evidence += eTerms[k];
            double[] probs = new double[nc];
            for (int k = 0; k < nc; ++k)
                probs[k] = eTerms[k] / evidence;
            Console.WriteLine("Probabilities: ");
            
            for (int k = 0; k < nc; ++k)
                Console.Write(probs[k].ToString("F4") + " ");
            Console.WriteLine("\n");
            int pc = ArgMax(probs);
            Console.WriteLine("Predicted class: ");
            Console.WriteLine(pc);
            Console.WriteLine("\nEnd naive Bayes ");
            Console.ReadLine();
        } // Main
        
        static string[][] MatrixString(int rows, int cols)
        {
            string[][] result = new string[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new string[cols];
            return result;
        }
        
        static int[][] MatrixInt(int rows, int cols)
        {
            int[][] result = new int[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new int[cols];
            return result;
        }
        
        static string[][] LoadData(string fn, int rows,
        int cols, char delimit)
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
        


        static int ArgMax(double[] vector)
        {
            int result = 0;
            double maxV = vector[0];
            for (int i = 0; i < vector.Length; ++i)
            {
                if (vector[i] > maxV)
                {
                    maxV = vector[i];
                    result = i;
                }
            }
            return result;
        }

        //Static network


    } // Program
} // ns

//2. Naive Bayes with Gause Distribution 
//

//=============================================================================================================================================================================

//3. Logistic Regression 

using System;
using System.IO;
// .NET (Core) 6

namespace PeopleLogisticRegression
{
    internal class PeopleLogRegProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nLogistic regression raw C# demo ");

            // 0. get ready
            Random rnd = new Random(0);

            // 1. load train data

            Console.WriteLine("\nLoading People data ");
            string fn = "D:/Learning C#/datatraining.txt";
            int[] cols = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            double[][] allTrain = MatLoad(fn, 200, cols, '\t');
            int[] xCols = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            double[][] xTrain = Extract(allTrain, xCols);
            int[] yCol = new int[] { 0 };
            double[][] yTrain = Extract(allTrain, yCol);

            // 1b. load test data
            fn = "D:/Learning C#/datatest.txt";
            cols = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            double[][] allTest = MatLoad(fn, 40, cols, '\t');
            xCols = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            double[][] xTest = Extract(allTest, xCols);
            yCol = new int[] { 0 };
            double[][] yTest = Extract(allTest, yCol);

            // 2. create model
            Console.WriteLine("\n Creating logistic regression model ");
            double[] wts = new double[8];
            double lo = -0.01; double hi = 0.01;
            for (int i = 0; i < wts.Length; ++i)
        wts[i] = (hi - lo) * rnd.NextDouble() + lo;
            double bias = 0.0;

            // 3. train model
            double lrnRate = 0.005;
            int maxEpochs = 10000;
            Console.WriteLine("\nTraining using SGD with lrnRate = " +
              lrnRate);
            int[] indices = new int[200];
            for (int i = 0; i < indices.Length; ++i)
        indices[i] = i;
            for (int epoch = 0; epoch < maxEpochs; ++epoch)
			{
                Shuffle(indices, rnd);



                for (int ii = 0; ii < indices.Length; ++ii)
			{
                    int i = indices[ii];
                    double[] x = xTrain[i];
                    double y = yTrain[i][0];  // target 0 or 1
                    double p = ComputeOutput(wts, bias, x);
                    // Console.WriteLine(p);
                    //Console.ReadLine();

                    // update all wts and the bias
                    for (int j = 0; j < wts.Length; ++j)
            wts[j] += lrnRate * x[j] * (y - p);
                    bias += lrnRate * (y - p);
                }


                if (epoch % 1000 == 0)
                {
                    double loss = MSELoss(wts, bias, xTrain, yTrain);
                    Console.WriteLine("epoch = " +
                      epoch.ToString().PadLeft(4) + " | " +
                      " loss = " + loss.ToString("F4"));
                }
            } // for
            Console.WriteLine("Done ");

            // 4. evaluate model 
            Console.WriteLine("\nEvaluating trained model ");
            double accTrain = Accuracy(wts, bias, xTrain, yTrain);
            Console.WriteLine("Accuracy on train data: " +
              accTrain.ToString("F4"));
            double accTest = Accuracy(wts, bias, xTest, yTest);
            Console.WriteLine("Accuracy on test data: " +
              accTest.ToString("F4"));

            // 5. use model
            Console.WriteLine("\n[33, Nebraska, $50,000, moderate]: ");
            double[] inpt =
              new double[] { 0.33, 0, 1, 0, 0.50000, 0, 1, 0 };
            double pVal = ComputeOutput(wts, bias, inpt);
            Console.WriteLine("p-val = " + pVal.ToString("F4"));
            if (pVal < 0.5)
        Console.WriteLine("class 0 (male) ");
      else
                Console.WriteLine("class 1 (female) ");

            // 6.TODO: save wts and bias to file

            Console.WriteLine("\nEnd logistic regression C# demo ");
            Console.ReadLine();
        } // Main

        public static void Shuffle(int[] arr, Random rnd)
        {
            // Fisher-Yates algorithm
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
      {
                int ri = rnd.Next(i, n);  // random index
                int tmp = arr[ri];
                arr[ri] = arr[i];
                arr[i] = tmp;
            }
        }

        public static double ComputeOutput(double[] w,
          double b, double[] x)
        {
            double z = 0.0;
            for (int i = 0; i < w.Length; ++i)
      {
                z += w[i] * x[i];
            }
            z += b;
            double p = 1.0 / (1.0 + Math.Exp(-z));
            return p;
        }

        public static double Accuracy(double[] w, double b,
          double[][] dataX, double[][] dataY)
        {
            int nCorrect = 0; int nWrong = 0;
            for (int i = 0; i < dataX.Length; ++i)
        {
                double[] x = dataX[i];
                int y = (int)dataY[i][0];
                double p = ComputeOutput(w, b, x);
                if ((y == 0 && p < 0.5) ||
                  (y == 1 && p == 0.5))
          nCorrect += 1;
        else
                    nWrong += 1;
            }
            double acc = (nCorrect * 1.0) / (nCorrect + nWrong);
            return acc;
        }
		//MSELoss for model
        public static double MSELoss(double[] w, double b,
          double[][] dataX, double[][] dataY)
        {
            double sum = 0.0;
            for (int i = 0; i < dataX.Length; ++i)
        {
                double[] x = dataX[i];
                double y = dataY[i][0];
                double p = ComputeOutput(w, b, x);
                sum += (y - p) * (y - p);
            }
            double mse = sum / dataX.Length;
            return mse;
        }

        public static double[][] MatLoad(string fn, int nRows,
          int[] cols, char sep)
        {
            int nCols = cols.Length;
            double[][] result = MatCreate(nRows, nCols);
            string line = "";
            string[] tokens = null;
            FileStream ifs = new FileStream(fn, FileMode.Open);
            StreamReader sr = new StreamReader(ifs);

            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.StartsWith("#") == true)
                    continue;
                tokens = line.Split(sep);
                for (int j = 0; j < nCols; ++j)
        {
                    int k = cols[j];  // into tokens
                    result[i][j] = double.Parse(tokens[k]);
                }
                ++i;
            }
            sr.Close(); ifs.Close();
            return result;
        }

        public static double[][] MatCreate(int rows, int cols)
        {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
        result[i] = new double[cols];
            return result;
        }

        public static void MatShow(double[][] mat, int dec,
          int wid)
        {
            int nRows = mat.Length;
            int nCols = mat[0].Length;
            for (int i = 0; i < nRows; ++i)
      {
                for (int j = 0; j < nCols; ++j)
        {
                    double x = mat[i][j];
                    Console.Write(x.ToString("F" + dec).PadLeft(wid));
                }
                Console.WriteLine("");
                // Utils.VecShow(mat[i], dec, wid);
            }
        }

        public static double[][] Extract(double[][] mat,
          int[] cols)
        {
          
            int nRows = mat.Length;
            int nCols = cols.Length;
            double[][] result = MatCreate(nRows, nCols);
            for (int i = 0; i < nRows; ++i)
        {
                for (int j = 0; j < nCols; ++j)  // idx into src cols
        {
                    int srcCol = cols[j];
                    int destCol = j;
                    result[i][destCol] = mat[i][srcCol];
                }
            }
            return result;


        }

    } // Program
} // ns
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////