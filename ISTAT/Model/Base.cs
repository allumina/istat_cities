using System;
namespace ISTAT.Model
{
    public abstract class Base
    {
        #region Private members
        protected double latitude;
        protected double longitude;
        #endregion

        #region Public properties
        public Double Latitude { get { return this.latitude; } set { this.latitude = value; } }
        public Double Longitude { get { return this.longitude; } set { this.longitude = value; } }
        #endregion

        #region Constructor(s)
        public Base()
        {
            this.latitude = 0.0;
            this.longitude = 0.0;
        }
        #endregion
    }
}
