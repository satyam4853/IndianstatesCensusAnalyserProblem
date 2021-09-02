using IndianStateCensusAnalyser;
using NUnit.Framework;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;
using IndianStateCensusAnalyser.POCO;
namespace CensusAnalyserTest

{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPrSqKm";
        static string indianStateCodeHedaers = "SrNo,State Name , Tin ,StateCode";
        string indianstateCensusFilePath = @"C:\Users\SATYAM VAISHNAV\source\repos\IndianStateCensusAnalyser\CensusData.csv";
        string wrongExtensionFilePath = @"C:\Users\SATYAM VAISHNAV\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVAdapterFactory.cs";
        string wrongFilePath = @"C:\Users\SATYAM VAISHNAV\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\DTO\CensusDTO.cs";
        string wrongheadersFilePath = @"C:\Users\SATYAM VAISHNAV\source\repos\IndianStateCensusAnalyser\WrongHeaders.csv";
        string wrongDelimitersFilePath = @"C:\Users\SATYAM VAISHNAV\source\repos\IndianStateCensusAnalyser\WrongDelimeter.csv";
        string indianstateCodeFilepath = @"C:\Users\SATYAM VAISHNAV\source\repos\IndianStateCensusAnalyser\StateCode.csv";






        IndianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;



        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianstateCensusFilePath, "State,Population,Area,Density");
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianstateCodeFilepath, "SrNo,State Name , Tin ,StateCode");
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
            
        }
    }
}