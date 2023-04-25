////import library 
///

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MachineLearningLib
{
    public class NaiveBayes
   
    {

        #region Properties
      
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
        

        public NaiveBayes() 
        
        {
            
        }
        #endregion

        #region Initialization
        
        public void Initialization()
        
        {
            
            
            // Load Input Data
            NaiveBayes p = new NaiveBayes();
            string fn = "../Data/IrisDataTrainning.txt";
            string[][] data = p.LoadData(fn, num_samples, num_features, ',');
            MessageBox.Show("Done Load Data");
            //return data;
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
        }
        #endregion

        #region Training
        public void Training()
        {
        
            double[][] data = LoadData(fn, N, num_features + 1, ',');
            // mean calculation
            var means = MeanCalculation(data);


            // varian calucatio
            var varians = VarianCalculation(data);


            //gause properties
            var gauges = GaugeCalculation(means, varians);


        }

        /// <summary>
        /// Mean calculation for data
        /// </summary>
        /// <param name="input_data"></param>
        /// <returns></returns>
        private double[,] MeanCalculation(double[,] input_data)
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
