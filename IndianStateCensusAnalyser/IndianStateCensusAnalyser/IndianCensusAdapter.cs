using System;
using IndianStateCensusAnalyser;
using System.Collections.Generic;
using System.Text;
using IndianStateCensusAnalyser.POCO;
using System.Linq;


namespace IndianStateCensusAnalyser
{
   public class IndianCensusAdapter : CensusAdapter

    {
        string[] censusdata;
        Dictionary<string, CensusDTO> dataMap;
        private object p;

        public Dictionary<string, CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            dataMap = new Dictionary<string, CensusDTO>();
            censusdata = GetCensusData(csvFilePath,  dataHeaders);
            foreach (string data in censusdata.Skip(1))
            {
                if (!data.Contains(","))
                {
                    throw new CensusAnalyserException("File Contains Wrong Delimeter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMETER);
                }
           
            string[] column = data.Split(",");
            if (csvFilePath.Contains("IndiastateCode.csv"))
                dataMap.Add(column[1], new CensusDTO(new stateCodeDAO(column[0], column[1], column[2] ,column[3])));
            if (csvFilePath.Contains("IndiaStateCensusdata.csv"))
                dataMap.Add(column[0], new CensusDTO(new CensusDataDAO(column[0], column[1], column[2], column[3])));

            }
            return dataMap.ToDictionary(p => p.Key, p => p.Value);
        }
    }
}

