using System;
using System.IO;
using Newtonsoft.Json;

using ISTAT.Model;
using ISTAT.Data;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

// 0    Codice Regione;
// 1    Codice dell'Unità territoriale sovracomunale (valida a fini statistici)
// 2    Codice Provincia (Storico)
// 3    Progressivo del Comune
// 4    Codice Comune formato alfanumerico
// 5    Denominazione (Italiana e straniera);
// 6    Denominazione in italiano
// 7    Denominazione altra lingua
// 8    Codice Ripartizione Geografica
// 9    Ripartizione geografica
// 10   Denominazione regione
// 11   Denominazione dell'Unità territoriale sovracomunale (valida a fini statistici)
// 12   Flag Comune capoluogo di provincia/città metropolitana/libero consorzio;
// 13   Sigla automobilistica
// 14   Codice Comune formato numerico
// 15   Codice Comune numerico con 110 province (dal 2010 al 2016)
// 16   Codice Comune numerico con 107 province (dal 2006 al 2009)
// 17   Codice Comune numerico con 103 province (dal 1995 al 2005)
// 18   Codice Catastale del comune;Popolazione legale 2011 (09/10/2011)
// 19   NUTS1
// 20   NUTS2
// 21   NUTS3
namespace ISTAT
{
    class Program
    {
        const char CSV_SEPARATOR = ';';

        static Country country;

        static void Main(string[] args)
        {
            ProcessData();
            Console.WriteLine(JsonConvert.SerializeObject(country));

            StreamWriter sw = new StreamWriter("output.json", false);
            sw.Write(JsonConvert.SerializeObject(country, Formatting.Indented));
            sw.Close();

            Console.WriteLine("Press ENTER");
            Console.ReadLine();
        }

        static void ProcessData()
        {
            country = new Country();
            country.Name = "Italia";
            country.Code = "it";
            GeoResponse geo = Geocode(country.Name);
            if (geo != null)
            {
                country.Latitude = geo.Latitude;
                country.Longitude = geo.Longitude;
            }

            int counter = 0;
            string line;
            StreamReader sr = new StreamReader("Data/istat_20190630.csv");
            while ((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(CSV_SEPARATOR);
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = values[i].Trim();
                }

                Region region = ParseRegion(values);
                District district = ParseDistrict(values, region);
                City city = ParseCity(values, district);

                counter++;
            }
            sr.Close();
        }

        static Region ParseRegion(string[] values)
        {
            Region temp = new Region();
            bool isNew = true;

            foreach (Region region in country.Regions)
            {
                if (region.Code.Equals(values[0]))
                {
                    temp = region;
                    isNew = false;
                    break;
                }
            }

            if (isNew)
            {
                temp.Code = values[0];
                temp.ZoneCode = int.Parse(values[8]);
                temp.ZoneName = values[9];
                temp.Name = values[10];

                Console.WriteLine("Region: " + temp.Name);

                GeoResponse geo = Geocode(temp.Name);
                if (geo != null)
                {
                    temp.Latitude = geo.Latitude;
                    temp.Longitude = geo.Longitude;
                }


                country.Regions.Add(temp);
            }

            return temp;
        }

        static District ParseDistrict(string[] values, Region region)
        {
            District temp = new District();
            bool isNew = true;
            foreach (District district in region.Districts)
            {
                if (district.Code.Equals(values[2]))
                {
                    temp = district;
                    isNew = false;
                    break;
                }
            }

            if (isNew)
            {
                temp.Code = values[2];
                temp.Name = values[11];
                temp.TerritorialUnitCode = values[8];
                temp.TerritorialUnit = values[9];
                temp.Abbreviation = values[13];

                Console.WriteLine("District: " + temp.Name);

                GeoResponse geo = Geocode(temp.Name);
                if (geo != null)
                {
                    temp.Latitude = geo.Latitude;
                    temp.Longitude = geo.Longitude;
                }

                region.Districts.Add(temp);
            }

            return temp;
        }

        static City ParseCity(string[] values, District district)
        {
            City temp = new City();
            bool isNew = true;
            foreach (City city in district.Cities)
            {
                if (city.Code.Equals(values[4]))
                {
                    temp = city;
                    isNew = false;
                    break;
                }
            }

            if (isNew)
            {
                temp.Code = values[4];
                temp.Name = values[5];
                temp.OriginalName = values[6];
                temp.AlternativeName = values[7];
                temp.Progressive = values[3];
                temp.IsDistrict = values[12] == "1" ? true : false;

                temp.NumericCode = int.Parse(values[14]);
                temp.Code110 = values[15];
                temp.Code107 = values[16];
                temp.Code103 = values[17];
                temp.CadastralCode = values[18];
                temp.Population = int.Parse(values[19].Replace(".", "").Replace(",", ""));

                temp.NUTS1 = values[20];
                temp.NUTS2 = values[21];
                temp.NUTS3 = values[22];

                Console.WriteLine("City: " + temp.Name);

                GeoResponse geo = Geocode(temp.Name);
                if (geo != null)
                {
                    temp.Latitude = geo.Latitude;
                    temp.Longitude = geo.Longitude;
                }

                district.Cities.Add(temp);
            }

            return temp;
        }

        static GeoResponse Geocode(string name)
        {
            GeoResponse output = null;
            string baseUrl = "https://geocode.localfocus.nl/geocode.php?q={0}&boundary=ITA";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(string.Format(baseUrl, name)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    if (responseString != null)
                    {
                        List<GeoResponse> items = JsonConvert.DeserializeObject<List<GeoResponse>>(responseString);
                        foreach (GeoResponse item in items)
                        {
                            if (output == null || (output != null && output.Confidence < item.Confidence))
                            {
                                output = item;
                            }
                        }
                    }
                }
            }
            return output;
        }
    }
}
