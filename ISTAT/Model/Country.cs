using System;
using System.Collections.Generic;

namespace ISTAT.Model
{
    public class Country : Base
    {
        #region Private members
        private string code;

        private string name;
        private List<Region> regions;
        #endregion

        #region Public properties
        /// <summary>
        /// Codice della Regione (formato alfanumerico).
        /// Codice di due caratteri alfanumerici, con validità nel range 01- 20
        /// </summary>
        public string Code { get { return this.code; } set { this.code = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public List<Region> Regions { get { return this.regions; } set { this.regions = value; } }
        #endregion

        #region Constructor(s)
        public Country() : base()
        {
            this.name = null;
            this.code = null;
            this.regions = new List<Region>();
        }
        #endregion
    }
}
