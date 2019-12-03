using System;
using System.Collections.Generic;

namespace ISTAT.Model
{
    public class District : Base
    {
        #region Private members
        private string code;
        private string territorialUnitCode;
        private string territorialUnit;
        private string name;
        private string abbreviation;
        private List<City> cities;
        #endregion

        #region Public properties
        /// <summary>
        /// Codice Provincia (Storico)
        ///
        /// NOTA: Con l'istituzione delle Città Metropolitane il codice di provincia delle CM istituite permane al solo scopo di costituire il Codice del comune.
        /// Allo stesso scopo permangono i codici delle soppresse province del Friuli-Venezia Giulia (Gorizia, Trieste e Pordenone),
        /// cessate secondo le modalità espresse con Legge regionale 20 dicembre 2016, n. 20 (Suppl. ord. n. 55 al B.U.R n. 50 del 14 dicembre 2016).
        /// </summary>
        public string Code { get { return this.code; } set { this.code = value; } }

        /// <summary>
        /// Codice dell'Unità territoriale sovracomunale (valida a fini statistici)
        /// </summary>
        public string TerritorialUnitCode { get { return this.territorialUnitCode; } set { this.territorialUnitCode = value; } }

        /// <summary>
        /// Ripartizione geografica
        /// </summary>
        public string TerritorialUnit { get { return this.territorialUnit; } set { this.territorialUnit = value; } }

        /// <summary>
        /// Denominazione dell'Unità territoriale sovracomunale (valida a fini statistici).
        ///
        /// Denominazione della provincia, città metropolitana, libero consorzio di comuni o ex provincia del Friuli-venezia Giulia di appartenenza del comune.
        /// La denominazione delle città metropolitane e dei liberi consorzi è stata ereditata dalla provincia di provenienza.
        /// </summary>
        public string Name { get { return this.name; } set { this.name = value; } }

        /// <summary>
        /// Sigla automobilistica
        /// </summary>
        public string Abbreviation { get { return this.abbreviation; } set { this.abbreviation = value; } }


        public List<City> Cities {  get { return this.cities; } set { this.cities = value; } }       
        #endregion

        #region Constructor(s)
        public District() : base()
        {
            this.code = null;
            this.territorialUnitCode = null;
            this.territorialUnit = null;
            this.name = null;
            this.abbreviation = null;
            this.cities = new List<City>();
        }
        #endregion

    }
}
