using System;
namespace ISTAT.Model
{
    public class City : Base
    {
        #region Private members
        private string code;
        private string progressive;
        private string name;
        private string originalName;
        private string alternativeName;
        private bool isDistrict;
        private int numericCode;
        private string code110;
        private string code107;
        private string code103;
        private string cadastralCode;
        private string nuts1;
        private string nuts2;
        private string nuts3;
        private int population;
        #endregion

        #region Public properties
        /// <summary>
        /// Codice Comune formato alfanumerico
        ///
        /// Codice Istat del Comune (sei caratteri, formato alfanumerico).
        /// Si ottiene dalla concatenazione del Codice Provincia con il Progressivo del comune.
        /// </summary>
        public string Code { get { return this.code; } set { this.code = value;  } }

        /// <summary>
        /// Progressivo del Comune
        ///
        /// Progressivo alfanumerico di tre caratteri assegnato al comune nell'ambito della provincia di appartenenza.
        /// E' un numero progressivo che parte da '001' all'interno di ogni provincia.
        /// 
        /// NOTA: E' un progressivo alfanumerico di tre caratteri assegnato ai comuni nell'ambito della provincia di appartenenza.
        /// Concatenato con il codice di provincia costituisce il Codice comune
        /// </summary>
        public string Progressive { get { return this.progressive; } set { this.progressive = value; } }

        /// <summary>
        /// Denominazione (Italiana e straniera)
        ///
        /// Denominazione ufficiale del Comune in lingua italiana e straniera.
        /// La denominazione ufficiale dei comuni della provincia di Bolzano/Bozen e di alcuni comuni dell Friuli-Venezia Giulia
        /// è definita dall'associazione del nome italiano a quello straniero. Per le denominazioni bilingue è previsto
        /// l'uso del simbolo separatore: "/" per i comuni della provincia di Bolzano/Bozen, e "-" per tutti gli altri.
        /// </summary>
        public string Name { get { return this.name; } set { this.name = value; } }

        /// <summary>
        /// Denominazione in italiano
        ///
        /// Denominazione solo in lingua italiana del Comune.
        /// </summary>
        public string OriginalName { get { return this.originalName; } set { this.originalName = value; } }

        /// <summary>
        /// Denominazione altra lingua
        ///
        /// Denominazione del Comune in lingua diversa dall'italiano.
        /// </summary>
        public string AlternativeName { get { return this.alternativeName; } set { this.alternativeName = value; } }

        /// <summary>
        /// Flag Comune capoluogo di provincia/città metropolitana/libero consorzio
        ///
        /// 1=Comune capoluogo; 0=Comune non è capoluogo. 
        /// </summary>
        public bool IsDistrict { get { return this.isDistrict; } set { this.isDistrict = value; } }

        /// <summary>
        /// Codice Comune formato numerico
        ///
        /// Codice Istat del Comune in formato numerico.
        /// </summary>
        public int NumericCode { get { return this.numericCode; }set { this.numericCode = value;  } }

        /// <summary>
        /// Codice Comune numerico con 110 province (dal 2010 al 2016)
        ///
        /// Codice Istat del Comune (in formato numerico) riferito alla situazione antecedente alla soppressione
        /// delle quattro province sarde di Carbonia-Iglesias, Medio Campidano, Olbia-Tempio, Ogliastra e
        /// della costituzione della nuova provincia del Sud Sardegna.
        /// Si ottiene dalla concatenazione del Codice Provincia (110 province) con Progressivo del comune.
        /// Ha validità nel periodo che va dalla costituzione delle tre nuove province del 2009 al ridisegno dei
        /// confini provinciali della Sardegna in conseguenza dell'attuazione del piano di riordino territoriale dell'Intera Isola.
        /// </summary>
        public string Code110 { get { return this.code110; } set { this.code110 = value; } }

        /// <summary>
        /// Codice Comune numerico con 107 province (dal 2006 al 2009)
        ///
        /// Codice Istat del Comune (in formato numerico) riferito alla situazione antecedente alla costituzione delle tre nuove
        /// province di Monza e della Brianza, Fermo e Barletta-Andria-Trani.
        /// Si ottiene dalla concatenazione del Codice Provincia (107 province) con Progressivo del comune.
        /// Ha validità nel periodo che va dalla costituzione delle nuove province della Sardegna (2006) alla istituzione di tre nuove province nel 2009
        /// </summary>
        public string Code107 { get { return this.code107; } set { this.code107 = value; } }

        /// <summary>
        /// Codice Comune numerico con 103 province (dal 1995 al 2005)
        ///
        /// Codice Istat del Comune (in formato numerico) riferito alla situazione antecedente alla costituzione delle quattro nuove province della Sardegna.
        /// Si ottiene dalla concatenazione del Codice Provincia (103 province) con il Progressivo del comune.
        /// Ha validità nel periodo che va dal 1995 al 2005, prima della istituzione delle nuove province della Sardegna
        /// </summary>
        public string Code103 { get { return this.code103; } set { this.code103 = value; } }

        /// <summary>
        /// Codice Catastale del comune
        ///
        /// E' il codice assegnato al comune dall'Agenzia delle Entrate.
        /// E' un codice composto da quattro caratteri, il primo dei quali alfabetico e gli altri tre numerici.
        /// Il codice è stato assegnato inizialmente seguendo l'ordinamento alfabetico crescente dell'elenco di tutti i
        /// comuni di Italia, indipedentemente dalla Provincia di appartenenza.
        /// Per i comuni di nuova istituzione viene assegnato il primo codice alfanumerico disponibile.
        /// </summary>
        public string CadastralCode { get { return this.cadastralCode; } set { this.cadastralCode = value; } }

        /// <summary>
        /// Popolazione legale 2011 (09/10/2011)
        /// </summary>
        public int Population { get { return this.population; } set { this.population = value; } }

        /// <summary>
        /// NUTS1
        ///
        /// Nomenclatura delle unità territoriali per le statistiche corrispondente al livello territoriale di Ripartizione
        ///
        /// E' il codice attualmente vigente. Cfr. Regolamenti (UE) n. 105/2007 del 1/02/07,  n. 176/2008, n. 31/2011 e n. 1319/2013. 
        /// </summary>
        public string NUTS1 { get { return this.nuts1; } set { this.nuts1 = value;  } }

        /// <summary>
        /// NUTS2
        ///
        /// Nomenclatura delle unità territoriali per le statistiche corrispondente al livello territoriale delle Regioni
        ///
        /// E' il codice attualmente vigente. Cfr. Regolamenti (UE) n. 105/2007 del 1/02/07,  n. 176/2008, n. 31/2011 e n. 1319/2013.
        /// Nella nomenclatura NUTS non è presente la regione di livello 2 "Trentino-Alto Adige/Südtirol";
        /// al suo posto compaiono la "Provincia autonoma di Bolzano/Bozen" (ITH1) e la "Provincia autonoma di Trento" (ITH2)
        /// 
        /// NOTA: Nella nomenclatura NUTS non è presente la regione di livello 2 "Trentino-Alto Adige/Südtirol";
        /// sono presenti invece la "Provincia autonoma di Bolzano/Bozen" (ITD1 nel 2006 e ITH1 nel 2010) e la
        /// "Provincia autonoma di Trento" (ITD2 nel 2006 e ITH2 nel 2010).
        /// </summary>
        public string NUTS2 { get { return this.nuts2; } set { this.nuts2 = value; } }

        /// <summary>
        /// NUTS3
        ///
        /// Nomenclatura delle unità territoriali per le statistiche corrispondente al livello territoriale delle Province
        ///
        /// Nomenclatura delle unità territoriali per le statistiche corrispondente al livello territoriale delle Province
        /// </summary>
        public string NUTS3 { get { return this.nuts3; } set { this.nuts3 = value; } }
        #endregion

        #region Constructor(s)
        public City() : base()
        {
            this.code = null;
            this.name = null;
            this.originalName = null;
            this.alternativeName = null;
            this.isDistrict = false;
            this.numericCode = 0;
            this.code110 = null;
            this.code107 = null;
            this.code103 = null;
            this.cadastralCode = null;
            this.nuts1 = null;
            this.nuts2 = null;
            this.nuts3 = null;
            this.population = 0;
        }
        #endregion
    }
}
