
using System;
using System.Collections.Generic;
using System.Text;
using IndianStateCensusAnalyser.POCO;


namespace IndianStateCensusAnalyser
{
   public class CSVAdapterFactory : Exception
    {
        private object dataHeaders;

        public Dictionary<string, CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath, string csvHeaders)
        {
            
            {
                switch (country)
                {
                    //Check countries
                    case (CensusAnalyser.Country.INDIA):
                        return new IndianCensusAdapter().LoadCensusData(csvFilePath, csvHeaders);
                    case (CensusAnalyser.Country.US):
                        return new USCensusAdapter().LoadUSCensusData(csvFilePath, dataHeaders);
                    default:
                        throw new CensusAnalyserException("No Such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
                }
            }
           
        }
    }
}
