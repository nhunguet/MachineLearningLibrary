////import library 
///

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MachineLearningLib
{
    public class NaiveBayes
   
    {

        #region Properties
        private int num_class;
        
        public int Num_class   // property

        {
            get { return num_class; }   // get method
            set { num_class = value; }  // set method
        }

        /// <summary>
        /// 
        /// set Number of Features 
        /// 
        /// </summary>
        private int num_features;


        public int Num_features// property

        {
            get { return num_features; }   // get method

            set { num_features = value; }  // set method
        }

        private int num_samples;


        /// <summary>
        /// //////
        /// Set Num of samples 
        /// </summary>
        public int Num_samples// property

        {
            get { return num_samples; }   // get method
            set { num_samples = value; }  // set method
        }


        #endregion

        #region Constructor / Destructor
        private double[][] data;
        public double[][] Data
        {

            get { return data; }
            set { this.data = value; }
        }

        public NaiveBayes() 
        
        {
            
        }
        #endregion

        #region Initialization

        public void Initialization()

        {
            // Load Input Data
         
            NaiveBayes p = new NaiveBayes();
        
            p.num_class = 3;
            
            p.num_features = 4;
            
            p.num_samples = 117;

            string fn = "D:/Data/IrisDataTrainning.txt";
            
            double[][] data = p.LoadData(fn, num_samples, num_features, ',');
            
            MessageBox.Show("Done Load Data");
            
          //  return data;
        }

        public double[][] LoadData(string fn, int rows, int cols, char delimit)

        {
            // Load data from file to data variable
            
            // data
            
            double[][] result = MatrixString(rows, cols);
            
            FileStream ifs = new FileStream(fn, FileMode.Open);
            StreamReader sr = new StreamReader(ifs);

            string[] tokens = null;
            string line = null; 
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

         //   return data.Length;
        }


        /// <summary>
        /// Function 
        /// </summary>

        public double[][] MatrixString(int rows, int cols)
        {
            double[][] result = new double[rows][];
            for (int i = 0; i < rows; ++i)
                result[i] = new double[cols];
            return result;
        }
        #endregion

        #region Setting
        public void Setting()
        {


            // do setting 
            // Get Param 
        }
        #endregion

        #region Training
        public void Training()
        {

            int[] classCts = new int[num_class];


            // mean calculation

            /// Caculate the mean of every feature 
            ///
            

            //var means = MeanCalculation(data);



            double[][] means = new double[num_class][];  // 3 calsses => 

            //////////////////////////////////////////////////

            for (int c = 0; c < num_class; ++c)
                means[c] = new double[num_features];



            ////
            ///

            double[][] condProbs = new double[num_class][];


            NaiveBayes p = new NaiveBayes();


            for (int c = 0; c < num_class; ++c)
                condProbs[c] = new double[num_features];



        }

        /// <summary>
        /// Mean calculation for data
        /// </summary>
        /// <param name="input_data"></param>
        /// <returns></returns>
        private double[,] MeanCalculation(double[,] in_data)
        {
            // 1. compute means 
            double[,] means = new double[1,1];  // [class][predictor]
            return means;
        }

        /// <summary>
        /// Calculate varian for data
        /// 
        /// 
        /// </summary>
        /// <param name="input_data"></param>
        /// <returns></returns>
        

        private double[,] VarianCalculation(double[,] input_data)

        
        {
            double[,] varians = new double[1, 1];

            return varians;
        }

        /// <summary>
        /// calculate gague for data
        /// </summary>
        /// 
        /// 
        /// <param name="means"></param>
        /// <param name="varians"></param>
        /// <returns></returns>
        private double[,] GaugeCalculation(double[,] means, double[,] varians)
        {
            double[,] gauges = new double[1, 1];

            return gauges;
        }
        #endregion

        #region Predict
        public void Predict()
        {
            //

            //

        }
        #endregion

        #region Save Model
        public void SaveModel()
        {
            // Serialize 

            // save to file

        }
        #endregion

        #region Load Model
        public void LoadModel()
        {
            // Read file

            // De-Serialize 

            // Create object
        }
        #endregion

    }
}
