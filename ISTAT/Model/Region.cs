using System;
using System.Collections.Generic;

namespace ISTAT.Model
{
    public class Region : Base
    {
        #region Private members
        private string code;
        private int zoneCode;
        private string zoneName;
        private string name;

        private List<District> districts;
        #endregion

        #region Public properties
        /// <summary>
        /// Codice Regione
        /// Codice di due caratteri alfanumerici, con validità nel range 01- 20.
        /// </summary>
        public string Code { get { return this.code; } set { this.code = value; } }

        /// <summary>
        /// Codice Ripartizione Geografica
        ///
        /// Classificazione delle Regioni in cinque ripartizioni geografiche: Nord-ovest, Nord-est, Centro, Sud e Isole.
        /// Codice di un carattere che assume i valori nell'intervallo 1-5.
        /// </summary>
        public int ZoneCode { get { return this.zoneCode; } set { this.zoneCode = value; } }

        /// <summary>
        /// Ripartizione geografica
        ///
        /// E' la denominazione della ripartizione geografica di appartenenza.
        /// </summary>
        public string ZoneName { get { return this.zoneName; } set { this.zoneName = value; } }

        /// <summary>
        /// Denominazione regione
        ///
        /// E' la denominazione della Regione di appartenenza.
        /// </summary>
        public string Name { get { return this.name;  } set { this.name = value; } }

        public List<District> Districts { get { return this.districts; } set { this.districts = value; } }
        #endregion

        #region Constructor(s)
        public Region() : base()
        {
            this.code = null;
            this.districts = new List<District>();
            this.zoneCode = 0;
            this.zoneName = null;
            this.name = null;
        }
        #endregion
    }
}
