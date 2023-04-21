using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineLearningLib
{
    public class NaiveBayes
    {

        #region Properties
        private int num_class = 0;
        private int num_features = 0;
        private int num_samples = 0;

        private double[,] data = null;
        #endregion

        #region Constructor / Destructor
        public NaiveBayes() 
        {
            
        }

        #endregion

        #region Initialization
        public void Initialization()
        {
            num_class = 3;
            num_features = 4;
            data = new double[num_class, num_features];

            // Load data
            num_samples = LoadData();
        }

        private int LoadData()
        {
            // Load data from file to data variable
            // data


            return data.Length;
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
            //for (int c = 0; c < N_class; ++c)
            //    means[c] = new double[N_feature];

            //for (int i = 0; i < N; ++i)
            //{
            //    int c = (int)data[i][N_feature];
            //    for (int j = 0; j < N_feature; ++j)  // ht, wt, foot
            //        means[c][j] += data[i][j];
            //}

            //for (int c = 0; c < N_class; ++c)
            //{
            //    for (int j = 0; j < N_feature; ++j)
            //        means[c][j] /= classCts[c];
            //}
            return means;
        }

        /// <summary>
        /// Calculate varian for data
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
