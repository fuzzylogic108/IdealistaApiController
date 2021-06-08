using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
//using NPOI.Util.Collections;
using System.Security.Policy;
using IdealistaApi;
using System.ComponentModel;

namespace IdealistaApi.Controller
{
    //Here all the classes for the exchange of data (the jsons of the apis)
    #region Data Classes
  
    /// <summary>
    /// Address obj 
    /// </summary>
   
    public class Address
    {
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public string visibility { get; set; }
        public string postalCode { get; set; }
        public string town { get; set; }
        public string country { get; set; }
        public string floor { get; set; }
        public float? latitude { get; set; }
        public float? longitude { get; set; }
        public String precision { get; set; }
        public string nsiCode { get; set; }
    }
    /// <summary>
    /// Generic class for all type of Feauters
    /// </summary>
    public class Features
    {
    }
    /// <summary>
    /// LAND
    /// </summary>
    public class FeaturesLand : Features
    {
        /// <summary>
        /// Enum: "urban" "countrybuildable" "countrynonbuildable"
        /// </summary>
        public string type { get; set; }
        public int areaPlot { get; set; }
        public int? areaBuildable { get; set; }
        public int? areaTradableMinimum { get; set; }
        public bool? classificationBlocks { get; set; }
        public bool? classificationChalet { get; set; }
        public bool? classificationCommercial { get; set; }
        public bool? classificationHotel { get; set; }
        public bool? classificationIndustrial { get; set; }
        public bool? classificationOffice { get; set; }
        public bool? classificationOther { get; set; }
        public bool? classificationPublic { get; set; }
        public int? floorsBuildable { get; set; }

        /// <summary>
        /// Enum: "inside_town" "outside_town" "unknown"
        /// </summary>
        public string location { get; set; }
        public int? nearestLocationKm { get; set; }
        public bool? electricity { get; set; }
        public bool? naturalGas { get; set; }
        public bool? roadAccess { get; set; }
        public bool? sewerage { get; set; }
        public bool? sidewalk { get; set; }
        public bool? streetLighting { get; set; }
        public bool? water { get; set; }
        public string accessType { get; set; }
        public int? depositMonths { get; set; }


        //nuovi campi

        /// <summary>
        ///  enum (not_free, free, bare_ownership, tenanted)
        /// </summary>
        public string currentOccupation { get; set; }
      
        public Boolean? hiddenPrice { get; set; }
    }
    /// <summary>
    /// STORAGE
    /// </summary>
    public class FeaturesStorage : Features
    {
        public Boolean? access24h;
        public int areaConstructed { get; set; }
        public int? areaHeight { get; set; }
        public Boolean? loadingDock;
        public Boolean? security24h;
        public int? priceCommunity { get; set; }
        public int? depositMonths { get; set; }


        //nuovi campi

        /// <summary>
        ///  enum (not_free, free, bare_ownership, tenanted)
        /// </summary>
        public string currentOccupation { get; set; }
        public Boolean? hiddenPrice { get; set; }



    }
    /// <summary>
    /// GARAGE
    /// </summary>
    public class FeaturesGarage:Features
    {

        public int? areaConstructed { get; set; }
        /// <summary>
        /// Enum: "unknown" "car_compact" "car_sedan" "motorcycle" "car_and_motorcycle" "two_cars and_more"
        /// </summary>
        public string garageCapacity { get; set; }

        public Boolean? securityAlarm ;

        public Boolean? liftAvailable ;

        public Boolean? parkingAutomaticDoor ;
        public Boolean? parkingPlaceCovered;
        /// <summary>
        /// Enum: "unknown" "depot" "parking_space"
        ///This feature only applies for Portugal and Italy garages. 'depot' if is a box garage. 'parking_space' if is a regular garage
        /// </summary>
        public string parkingType { get; set; }
        public Boolean? securityPersonnel;
        public int? priceCommunity { get; set; }
        public int? depositMonths { get; set; }


        //nuovi campi

        /// <summary>
        ///  enum (not_free, free, bare_ownership, tenanted)
        /// </summary>
        public string currentOccupation { get; set; }
        public Boolean? hiddenPrice { get; set; }

    }
    /// <summary>
    /// BUILDING
    /// </summary>
    public class FeaturesBuilding:Features
    {
        public int areaConstructed { get; set; }
        public int? areaTradableMinimum { get; set; }
        public int? builtYear { get; set; }


      
        public bool? classificationChalet { get; set; }
        public bool? classificationCommercial { get; set; }
        public bool? classificationHotel { get; set; }
        public bool? classificationIndustrial { get; set; }
        public bool? classificationOffice { get; set; }

        public bool classificationOther { get; set; }
        public string conservation { get; set; }

        /// <summary>
        /// [ 1 .. 999 ]
        /// </summary>
        public int? energyCertificatePerformance { get; set; }



        [Description(@"'title': 'energy certification rating',
    'enum': [
      'A',
      'A+',
      'A1',
      'A2',
      'A3',
      'A4',
      'B',
      'B-',
      'C',
      'D',
      'E',
      'F',
      'G',
      'exempt',
      'inProcess',
      'unknown'
    ]")]
        public string energyCertificateRating { get; set; }

        /// <summary>
        /// Enum: "dl-192_2005" "legge-90_2013"
        //Only for Italy.Indicates the legislation that applies to the energy rating, DL-192(2005) or LEGGE-90(2013) For dl-192_2005 the values accepted are: A+, A, B, C, D, E, F, G.For legge-90_2013 the values accepted are: A4, A3, A2, A1, B, C, D, E, F, G
        /// </summary>
        public string energyCertificateLaw { get; set; }

        public int? floorsBuilding { get; set; }

        public int? liftNumber { get; set; }

        public int parkingSpacesNumber { get; set; }
        public bool? propertyTenants { get; set; }
        public bool? securityPersonnel { get; set; }

        public int? depositMonths { get; set; }

        //nuovi campi

        /// <summary>
        ///  enum (not_free, free, bare_ownership, tenanted)
        /// </summary>
        public string currentOccupation { get; set; }
        public Boolean garden { get; set; }
        /// <summary>
        ///  enum (private, community)
        /// </summary>
        public string gardenType { get; set; }        
        public Boolean? hiddenPrice { get; set; }

    }
    /// <summary>
    /// COMMERCIAL
    /// </summary>
    public class FeaturesCommercial:Features
    {
        /// <summary>
        /// Enum: "retail" "industrial"
        /// </summary>
        public string type { get; set; }
        public int? areaConstructed { get; set; }
        public int? areaUsable { get; set; }
      
        public bool? auxiliaryEntrance { get; set; }
        public bool? bathroomAdapted { get; set; }
        public int? bathroomNumber { get; set; }
        public bool? bridgeCrane { get; set; }
        public int? builtYear { get; set; }
        public bool? conditionedAir { get; set; }
        /// <summary>
        /// REquired:	       Enum: "good" "toRestore"
        /// </summary>
        public string conservation { get; set; }

        /// <summary>
        /// [ 1 .. 999 ]
        /// </summary>
        public int? energyCertificatePerformance { get; set; }



        [Description(@"'title': 'energy certification rating',
    'enum': [
      'A',
      'A+',
      'A1',
      'A2',
      'A3',
      'A4',
      'B',
      'B-',
      'C',
      'D',
      'E',
      'F',
      'G',
      'exempt',
      'inProcess',
      'unknown'
    ]")]
        public string energyCertificateRating { get; set; }

        /// <summary>
        /// Enum: "dl-192_2005" "legge-90_2013"
        //Only for Italy.Indicates the legislation that applies to the energy rating, DL-192(2005) or LEGGE-90(2013) For dl-192_2005 the values accepted are: A+, A, B, C, D, E, F, G.For legge-90_2013 the values accepted are: A4, A3, A2, A1, B, C, D, E, F, G
        /// </summary>
        public string energyCertificateLaw { get; set; }
        public bool? equippedKitchen { get; set; }
        public int? facadeArea { get; set; }
        public int? floorsProperty { get; set; }
        public bool? heating { get; set; }
        public string lastActivity { get; set; }
        /// <summary>
        /// This option is only available if type = industrial.
        //This is a private field.Bear in mind that this is not going to be shown in idealista portal, it will be shown in the private website, if the client have one.
        /// </summary>
        public bool? loadingDock { get; set; }
        public bool? locatedAtCorner { get; set; }

        public int rooms { get; set; }

        public bool? securityAlarm { get; set; }
        public bool? securityDoor { get; set; }
        public bool? securityCamera { get; set; }
        public bool? storage { get; set; }

        public bool? smokeExtraction { get; set; }
        /// <summary>
        /// Rquired:Enum: "in_a_mall" "on_the_street" "mezzanine" "underground" "other" "unknown"
        /// </summary>
        public string location { get; set; }
        /// <summary>
        ///         This is a private field.Bear in mind that this is not going to be shown in idealista portal, it will be shown in the private website, if the client have one.
        /// </summary>
        private bool office { get; set; }
        public int? windowsNumber { get; set; }
        public int? priceCommunity { get; set; }
        public int? depositMonths { get; set; }

        public int? priceTransfer { get; set; }

        //nuovi campi

        /// <summary>
        ///  enum (not_free, free, bare_ownership, tenanted)
        /// </summary>
        public string currentOccupation { get; set; }
        /// <summary>
        /// enum (single, double)
        /// </summary>
        public string parkingSpaceCapacity { get; set; }
        public float? parkingSpaceArea { get; set; }//: double
        public Boolean? outdoorParkingSpaceAvailable { get; set; }
        /// <summary>
        /// enum (covered, uncovered)
        /// </summary>
        public string outdoorParkingSpaceType { get; set; }
        public int? outdoorParkingSpaceNumber { get; set; }
        public Boolean? hiddenPrice { get; set; }
    }


    /// <summary>
    /// OFFICE
    /// </summary>
    public class FeaturesOffice:Features
    {

        public int areaConstructed { get; set; }
        public bool? securitySystem { get; set; }
        public bool? accessControl { get; set; }
        public int? areaUsable { get; set; }
        public bool? bathroomInside { get; set; }
        public int? bathroomNumber { get; set; }
        /// <summary>
        /// Enum: "toilets" "fullEquiped" "both"
        /// </summary>
     
        public int? builtYear { get; set; }

        public bool? buildingAdapted { get; set; }

        /// <summary>
        /// Enum: "notAvailable" "cold" "cold/heat" "preInstallation"
        /// </summary>
        public string conditionedAirType { get; set; }
        /// <summary>
        /// REquired:	       Enum: "good" "toRestore"
        /// </summary>
        public string conservation { get; set; }
        public bool? doorman { get; set; }
        public bool? emergencyExit { get; set; }
        public bool? emergencyLights { get; set; }

        /// <summary>
        /// [ 1 .. 999 ]
        /// </summary>
        public int? energyCertificatePerformance { get; set; }



        [Description(@"'title': 'energy certification rating',
    'enum': [
      'A',
      'A+',
      'A1',
      'A2',
      'A3',
      'A4',
      'B',
      'B-',
      'C',
      'D',
      'E',
      'F',
      'G',
      'exempt',
      'inProcess',
      'unknown'
    ]")]
        public string energyCertificateRating { get; set; }

        /// <summary>
        /// Enum: "dl-192_2005" "legge-90_2013"
        //Only for Italy.Indicates the legislation that applies to the energy rating, DL-192(2005) or LEGGE-90(2013) For dl-192_2005 the values accepted are: A+, A, B, C, D, E, F, G.For legge-90_2013 the values accepted are: A4, A3, A2, A1, B, C, D, E, F, G
        /// </summary>
        public string energyCertificateLaw { get; set; }
        public bool? equippedKitchen { get; set; }
        public bool? extinguishers { get; set; }
        public bool? fireDetectors { get; set; }
        public bool? fireDoors { get; set; }

        public int? floorsBuilding { get; set; }
        public int? floorsProperty { get; set; }
        public bool? heating { get; set; }
        public bool? hotWater { get; set; }

        public int liftNumber { get; set; }

        public bool officeBuilding { get; set; }
        public bool? orientationEast { get; set; }
        public bool? orientationNorth { get; set; }
        public bool? orientationSouth { get; set; }
        public bool? orientationWest { get; set; }

        public int parkingSpacesNumber { get; set; }
        /// <summary>
        /// Rquired:Enum: "openPlan" "withScreens" "withWalls" "unknown"
        /// </summary>
        public string roomsSplitted { get; set; }
        public bool? securityDoor { get; set; }
        public bool? sprinklers { get; set; }
        public bool? suspendedCeiling { get; set; }
        public bool? suspendedFloor { get; set; }
        public bool? storage { get; set; }
        public bool? windowsDouble { get; set; }
        /// <summary>
        /// Not Rquired:Enum: "internal" "external"
        /// </summary>
        public string windowsLocation { get; set; }

        /// <summary>
        /// Monthly community fees. It can only be defined for sale operation in Spain and Portugal. In Italy, it can be defined for both rent and sale operations
        /// </summary>
        public int? priceCommunity { get; set; }
        public int? depositMonths { get; set; }
        public int? areaTradableMinimum { get; set; }


        //nuovi campi

        /// <summary>
        ///  enum (not_free, free, bare_ownership, tenanted)
        /// </summary>
        public string currentOccupation { get; set; }
       
        public Boolean? hiddenPrice { get; set; }




    }

    /// <summary>
    /// FLAT
    /// </summary>
    public class FeaturesFlat:Features
    {

        public int areaConstructed { get; set; }
        public int? areaUsable { get; set; }        
        public bool? balcony { get; set; }


        public int bathroomNumber { get; set; }

        public int? builtYear { get; set; }

        public Boolean? conditionedAir ;


        /// <summary>
        /// Required:Enum: "good" "toRestore" "fully_reformed"
        /// </summary>
        public string conservation { get; set; }


        public Boolean? doorman;
        public Boolean? duplex ;
        /// <summary>
        /// Not Required:Enum: "equipped_kitchen_and_furnished" "equipped_kitchen_and_not_furnished" "not_equipped"
        //Only available for rent operation.Equipped kitchen with appliances and furnished, only equipped kitchen with appliances or neither of both
        /// </summary>
        public string equipment { get; set; }


        /// <summary>
        /// [ 1 .. 999 ]
        /// </summary>
        public int? energyCertificatePerformance { get; set; }



        [Description(@"'title': 'energy certification rating',
    'enum': [
      'A',
      'A+',
      'A1',
      'A2',
      'A3',
      'A4',
      'B',
      'B-',
      'C',
      'D',
      'E',
      'F',
      'G',
      'exempt',
      'inProcess',
      'unknown'
    ]")]
        public string energyCertificateRating { get; set; }
        public Boolean? garden { get; set; }
        public Boolean? isInTopFloor { get; set; }
        public Boolean? handicappedAdaptedAccess { get; set; }
        public Boolean? handicappedAdaptedUse { get; set; }
        /// <summary>
        /// Required
        /// </summary>
        public Boolean liftAvailable { get; set; }
        public Boolean? orientationNorth
        { get; set; }
        public Boolean? orientationSouth { get; set; }
        public Boolean? orientationWest { get; set; }
        public Boolean? orientationEast { get; set; }
        public Boolean? parkingAvailable { get; set; }
        public Boolean? parkingIncludedInPrice { get; set; }



        public int? parkingPrice { get; set; }
        /// <summary>
        /// Flat on the top floor
        /// </summary>
        public Boolean? penthouse { get; set; }
        public Boolean? petsAllowed { get; set; }
        public Boolean? pool { get; set; }



        public int? rooms { get; set; }


        public Boolean? storage { get; set; }
        public Boolean? studio { get; set; }
        public Boolean? terrace { get; set; }
        public Boolean? wardrobes { get; set; }


        /// <summary>
        /// NOt required:Enum: "internal" "external"
        /// </summary>
        public string windowsLocation { get; set; }
        /// <summary>
        /// NOt required:Enum: Enum: "central_gas" "central_fuel_oil" "central_other" "individual_other" "individual_gas" "individual_electric" "individual_air_conditioning_heat_pump" "individual_propane_butane" "no_heating"
        /// </summary>
        public string heatingType { get; set; }

        /// <summary>
        /// Monthly community fees. It can only be defined for sale operation in Spain and Portugal. In Italy, it can be defined for both rent and sale operations
        /// </summary>
        public int? priceCommunity { get; set; }
        public int? depositMonths { get; set; }
        public int? priceReferenceIndex { get; set; }


        //nuovi campi

        /// <summary>
        ///  enum (not_free, free, bare_ownership, tenanted)
        /// </summary>
        public string currentOccupation { get; set; }
        /// <summary>
        ///  enum (private, community)
        /// </summary>
        public string gardenType { get; set; }
        /// <summary>
        /// enum (single, double)
        /// </summary>
        public string parkingSpaceCapacity { get; set; }
        public float? parkingSpaceArea { get; set; }//: double
        public Boolean? outdoorParkingSpaceAvailable { get; set; }
        /// <summary>
        /// enum (covered, uncovered)
        /// </summary>
        public string outdoorParkingSpaceType { get; set; }
        public int? outdoorParkingSpaceNumber { get; set; }
        public Boolean? hiddenPrice { get; set; }
    }

    /// <summary>
    /// HOUSE
    /// </summary>
    public class FeaturesHouse:Features
    {
        /// <summary>
        /// Required:Enum: "andar_moradia" "independent" "semidetached" "terraced" "villa"
        //Type availability varies between countries.Italy: villa.Portugal: andar_moradia.The rest of the types are available in each country.
        /// </summary>
        public string type { get; set; }
        public int areaConstructed { get; set; }
        public int? areaPlot { get; set; }
        public int? areaUsable { get; set; }
        public bool? balcony { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public int bathroomNumber { get; set; }

        public int? builtYear { get; set; }

        public Boolean? conditionedAir ;


        /// <summary>
        /// Required:Enum: "good" "toRestore" new "fully_reformed"
        /// </summary>
        public string conservation { get; set; }


        public Boolean? doorman ;
       
        /// <summary>
        /// Not Required:Enum: "equipped_kitchen_and_furnished" "equipped_kitchen_and_not_furnished" "not_equipped"
        //Only available for rent operation.Equipped kitchen with appliances and furnished, only equipped kitchen with appliances or neither of both
        /// </summary>
        public string equipment { get; set; }


        /// <summary>
        /// [ 1 .. 999 ]
        /// </summary>
        public int? energyCertificatePerformance { get; set; }



        [Description(@"'title': 'energy certification rating',
    'enum': [
      'A',
      'A+',
      'A1',
      'A2',
      'A3',
      'A4',
      'B',
      'B-',
      'C',
      'D',
      'E',
      'F',
      'G',
      'exempt',
      'inProcess',
      'unknown'
    ]")]
        public string energyCertificateRating { get; set; }
        public int? floorsBuilding { get; set; }
        public Boolean? garden { get; set; }
        /// <summary>
        /// Enum: "higher" "lower"
        //Specific and required field for 'andar de moradia' property type, indicates if the property is the one on the higher floor or the one in the lower floor
        /// </summary>
        public string floorLevel { get; set; }
        public Boolean? handicappedAdaptedAccess { get; set; }
        public Boolean? handicappedAdaptedUse { get; set; }
      
        public Boolean? orientationNorth
        { get; set; }
        public Boolean? orientationSouth { get; set; }
        public Boolean? orientationWest { get; set; }
        public Boolean? orientationEast { get; set; }
        public Boolean? parkingAvailable { get; set; }    
        public Boolean? petsAllowed { get; set; }
        public Boolean? pool { get; set; }



        public int? rooms { get; set; }


        public Boolean? storage { get; set; }
        public Boolean? terrace { get; set; }
        public Boolean? wardrobes { get; set; }

        /// <summary>
        /// NOt required:Enum: Enum: "central_gas" "central_fuel_oil" "central_other" "individual_other" "individual_gas" "individual_electric" "individual_air_conditioning_heat_pump" "individual_propane_butane" "no_heating"
        /// </summary>
        public string heatingType { get; set; }

        /// <summary>
        /// Monthly community fees. It can only be defined for sale operation in Spain and Portugal. In Italy, it can be defined for both rent and sale operations
        /// </summary>
        public int? priceCommunity { get; set; }
        public int? depositMonths { get; set; }
        public int? priceReferenceIndex { get; set; }


        //nuovi campi

        /// <summary>
        ///  enum (not_free, free, bare_ownership, tenanted)
        /// </summary>
        public string currentOccupation { get; set; }
        /// <summary>
        ///  enum (private, community)
        /// </summary>
        public string gardenType { get; set; }
        /// <summary>
        /// enum (single, double)
        /// </summary>
        public string parkingSpaceCapacity { get; set; }
        public float? parkingSpaceArea { get; set; }//: double
        public Boolean? outdoorParkingSpaceAvailable { get; set; }
        /// <summary>
        /// enum (covered, uncovered)
        /// </summary>
        public string outdoorParkingSpaceType { get; set; }
        public int? outdoorParkingSpaceNumber { get; set; }
        public Boolean? hiddenPrice { get; set; }

    }

    /// <summary>
    /// COUNTRYHOUSE
    /// </summary>
    public class FeaturesCountryHouse:Features
    {
        /// <summary>
        /// num: "countryhouse" "village" "castle" "palace" "baita" "rural" "casalecascina" "caseron" "cortijo" "masia" "masseria" "moinho" "montealentejano" "quinta" "solar" "terrera" "torre" "trullo"
        ///Allowed values depends on country.Common values are countryhouse, castle, village.
        ///IT:masseria, trullo, calicascine, baita        
        /// </summary>
        public string type { get; set; }
        public int areaConstructed { get; set; }
        public int? areaPlot { get; set; }
        public int? areaUsable { get; set; }
        public bool? balcony { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public int bathroomNumber { get; set; }

        public int? builtYear { get; set; }

        public Boolean? conditionedAir { get; set; }


        /// <summary>
        /// Required:Enum: "good" "toRestore" "fully_reformed"
        /// </summary>
        public string conservation { get; set; }

        public Boolean? chimney { get; set; }
        /// <summary>
        /// Not Required:Enum: "equipped_kitchen_and_furnished" "equipped_kitchen_and_not_furnished" "not_equipped"
        //Only available for rent operation.Equipped kitchen with appliances and furnished, only equipped kitchen with appliances or neither of both
        /// </summary>
        public string equipment { get; set; }


        /// <summary>
        /// [ 1 .. 999 ]
        /// </summary>
        public int? energyCertificatePerformance { get; set; }



        [Description(@"'title': 'energy certification rating',
    'enum': [
      'A',
      'A+',
      'A1',
      'A2',
      'A3',
      'A4',
      'B',
      'B-',
      'C',
      'D',
      'E',
      'F',
      'G',
      'exempt',
      'inProcess',
      'unknown'
    ]")]
        public string energyCertificateRating { get; set; }
        public int? floorsBuilding { get; set; }
        public Boolean? garden { get; set; }
       
        public Boolean? handicappedAdaptedAccess { get; set; }
        public Boolean? handicappedAdaptedUse { get; set; }

        public Boolean? orientationNorth
        { get; set; }
        public Boolean? orientationSouth { get; set; }
        public Boolean? orientationWest { get; set; }
        public Boolean? orientationEast { get; set; }
        public Boolean? parkingAvailable { get; set; }
        public Boolean? petsAllowed { get; set; }
        public Boolean? pool { get; set; }



        public int? rooms { get; set; }


        public Boolean? storage { get; set; }
        public Boolean? terrace { get; set; }
        public Boolean? wardrobes { get; set; }

        /// <summary>
        /// NOt required:Enum: Enum: "central_gas" "central_fuel_oil" "central_other" "individual_other" "individual_gas" "individual_electric" "individual_air_conditioning_heat_pump" "individual_propane_butane" "no_heating"
        /// </summary>
        public string heatingType { get; set; }

        /// <summary>
        /// Monthly community fees. It can only be defined for sale operation in Spain and Portugal. In Italy, it can be defined for both rent and sale operations
        /// </summary>
        public int? priceCommunity { get; set; }
        public int? depositMonths { get; set; }
        public int? priceReferenceIndex { get; set; }


        //nuovi campi

        /// <summary>
        ///  enum (not_free, free, bare_ownership, tenanted)
        /// </summary>
        public string currentOccupation { get; set; }
        /// <summary>
        ///  enum (private, community)
        /// </summary>
        public string gardenType { get; set; }
        /// <summary>
        /// enum (single, double)
        /// </summary>
        public string parkingSpaceCapacity { get; set; }
        public float? parkingSpaceArea { get; set; }//: double
        public Boolean? outdoorParkingSpaceAvailable { get; set; }
        /// <summary>
        /// enum (covered, uncovered)
        /// </summary>
        public string outdoorParkingSpaceType { get; set; }
        public int? outdoorParkingSpaceNumber { get; set; }
        public Boolean? hiddenPrice { get; set; }
    }

    /// <summary>
    /// ROOM
    /// </summary>
    public class FeaturesRoom:Features
    {
        /// <summary>
        /// Enum: "shared_flat" "shared_chalet"
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// Monthly community fees. It can only be defined for sale operation in Spain and Portugal. In Italy, it can be defined for both rent and sale operations
        /// </summary>
        public int? priceCommunity { get; set; }
        public int? depositMonths { get; set; }
        /// <summary>
        /// Required
        /// </summary>
        public int areaConstructed { get; set; }
        /// <summary>
        /// Required:Max number of flat mates allowed, including the tenant itself
        /// </summary>
        public int tenantNumber { get; set; }

        public int rooms { get; set; }
        public Boolean smokingAllowed { get; set; }

        /// <summary>
        /// Required
        /// </summary>
        public int bathroomNumber { get; set; }

        public Boolean? petsAllowed { get; set; }

        public int? minTenantAge { get; set; }
        public int? maxTenantAge { get; set; }

        public Boolean couplesAllowed { get; set; }
        public Boolean liftAvailable { get; set; }



        /// <summary>
        /// Required:Enum: "single" "double" "two_beds" "none"
        /// </summary>
        public string bedType { get; set; }

        public int minimalStay { get; set; }


        /// <summary>
        /// Not Required:Enum: "street_view" "courtyard_view" "no_window"
        /// </summary>
        public string windowView { get; set; }


        public Boolean? ownerLiving { get; set; }
        /// <summary>
        /// Required:Date when the room will be available. The format must be 'yyyy-mm' (year-month) and the range of values goes from the current month to the following 5 months
        /// </summary>
        public string availableFrom { get; set; }
        /// <summary>
        /// Not Required:Enum: "female" "male" "both"
        ///Gender of the tenants that currently lives in the property.This field is mandatory if occupiedNow = true, and is not allowed if occupiedNow 
        /// </summary>
        public string tenantGender { get; set; }

        public Boolean? conditionedAir { get; set; }
        public Boolean? internetAvailable { get; set; }
        public Boolean? houseKeeper { get; set; }

        /// <summary>
        /// Not Required:Enum: "central_gas" "central_fuel_oil" "central_other" "individual_other" "individual_gas" "individual_electric" "individual_air_conditioning_heat_pump" "individual_propane_butane" "no_heating"
        /// </summary>
        public string heatingType { get; set; }
        public Boolean? furnished { get; set; }
        public Boolean? cupboard { get; set; }
        public Boolean? privateBathroom { get; set; }

        /// <summary>
        /// Not Required:Enum: "female" "male" "no_preference"
        /// </summary>
        public string genderPreference { get; set; }


        /// <summary>
        /// Not Required:Enum: "student" "worker" "no_preference"
        /// </summary>
        public string occupation { get; set; }

        public Boolean? lgtbFriendly { get; set; }
        public Boolean? childrenAllowed { get; set; }
        public Boolean? isInTopFloor { get; set; }
        public Boolean occupiedNow { get; set; }
        public Boolean? tenantWorkers { get; set; }
        public Boolean? tenantStudents { get; set; }

        public int? minAge { get; set; }
        public int? maxAge { get; set; }

        public Boolean? equippedKitchen { get; set; }
        public Boolean? terrace { get; set; }
        public Boolean? doorman { get; set; }
        public Boolean? exteriorAccessibility { get; set; }
        public Boolean? interiorAccessibility { get; set; }
        public Boolean? pool { get; set; }
        public Boolean? garden { get; set; }
        /// <summary>
        /// Not Required:Enum: "quiet" "friendly" "animated"
        /// </summary>
        public string lifeStyle { get; set; }

        /// <summary>
        /// Not Required:Enum: "internal" "external"
        /// </summary>
        public string windowsLocation { get; set; }

    }
    

    public class Operation
    {
        public int? price { get; set; }
        public string type { get; set; }
        public int? priceCommunity { get; set; }
        
    }

    public class Description
    {
        public string language { get; set; }
        public string text { get; set; }
    }

    public class Image
    {
        public string label { get; set; }
        public int order { get; set; }
        public string url { get; set; }

    }

    public class ImageUpdate
    {
        public string label { get; set; }
        public int order { get; set; }

    }
    public class ImageRet : Image
    {
        public int imageId { get; set; }
        public string originalMD5CheckSum { get; set; }
        public string state { get; set; }
    }


    public class VTurl
    {
        public string url;
    }
    public class VTsReturn : GeneralReturn
    {
        public List<VTurl> virtualtours { get; set; }
    }
    public class Contact
    {

        public string name { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string primaryPhonePrefix { get; set; }
        public string primaryPhoneNumber { get; set; }
        public string secondaryPhonePrefix { get; set; }
        public string secondaryPhoneNumber { get; set; }
    }
    /// <summary>
    /// Generic object for property
    /// </summary>
    public class Property
    {
        public int propertyId { get; set; }
        /// <summary>
        /// Enum: "house" "flat" "building" "countryhouse" "garage" "land" "office" "commercial" "storage" "room"
        /// </summary>
        public string type { get; set; }
        public Address address { get; set; }
        public string code { get; set; }
        public string reference { get; set; }

        public string casaCode { get; set; }
        public int contactId { get; set; }
        public Object features { get; set; }
        public Operation operation { get; set; }
        public List<Description> descriptions { get; set; }
        public string additionalLink { get; set; }
        public string scope { get; set; }
        public string state { get; set; }

        /*
         Used in real implementations for internal datas

        [NonSerialized]        
        internal tempObj temp; 

        [NonSerialized]
        public List<Image> images;
        
        [NonSerialized]
        public String virtualT;
        */
    }

    public class Page
    {
        public int number { get; set; }
        public int size { get; set; }
        public int total { get; set; }
    }

    /// <summary>
    /// General api return class
    /// </summary>
    public class GeneralReturn
    {
        public string message { get; set; }
        public bool success { get; set; }


        
    }

    public class PublishInfo
    {
        public int publishedAds { get; set; }
        public int maxPublishedAds { get; set; }
    }

    /// <summary>
    /// Return type for property operations
    /// </summary>
    public class OpPropertyReturn : GeneralReturn
    {

        public string propertyCode { get; set; }
        public int propertyId { get; set; }      
        public PublishInfo publishInfo { get; set; }
    }
    /// <summary>
    /// Return type for new or modification operations
    /// </summary>
    public class NewModPropertyReturn: OpPropertyReturn
    {

       
        public string state { get; set; }
        public string scope { get; set; }

    }
    /// <summary>
    /// Return type for find property operations
    /// </summary>
    public class PropertyReturn : GeneralReturn
    {

        public Property property { get; set; }
       
    }
    /// <summary>
    /// Return type for return all properties operations
    /// </summary>
    public class PropertiesReturn : GeneralReturn
    {

        public List<Property> properties { get; set; }
        public Page page { get; set; }
        public int totalProperties { get; set; }
    }
    /// <summary>
    /// Return type for images operations
    /// </summary>

    public class OpImageReturn : GeneralReturn
    {
        public int imageId { get; set; }
    }
    /// <summary>
    /// Return type for retrive images operations
    /// </summary>
    public class ImagesReturn : GeneralReturn
    {
       
        public List<ImageRet> images { get; set; }
    }
    /// <summary>
    /// Return type for retrive image operations
    /// </summary>
    public class ImageReturn : GeneralReturn
    {

        public ImageRet image { get; set; }
    }


    /// <summary>
    /// Return type for contact operations
    /// </summary>
    public class ContactRet:Contact
    {
        public int contactId { get; set; }
       
    }
    /// <summary>
    /// Return type for contact operations
    /// </summary>
    public class OpContactReturn : GeneralReturn
    {
        public int contactId { get; set; }
    }
    /// <summary>
    /// Return type for contact operations
    /// </summary>
    public class FindContactReturn : GeneralReturn
    {
        public ContactRet contact { get; set; }
    }


    #endregion
    /// <summary>
    /// TOken obj for Auth fo idealista 
    /// </summary>

    #region Token adn Configuration classes
    public class Token
    {
        [JsonProperty("access_token")]
        public  string AccessToken { get; set; }

        [JsonProperty("token_type")]
        public  string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public  int ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public  string RefreshToken { get; set; }

        public  DateTime ExpiredDate { get; set; }
    }

    public class TokenAndConfigurationIdealista
    {

        public  Token TokenGen;
        public static ConfigurationIdealista Configuration;
        public static List<int?> AgenzieAbilitate = new List<int?>();

      
        /// <summary>
        /// Configuration object
        /// </summary>       
        static  TokenAndConfigurationIdealista()
        {
            //Configuration Format:
            // <add key="idealistaJson" value="{   'tokenurl':'https://xxxx.idealista.xx/oauth/token','basic_url':'https://xxxx.idealista.xx/v1/', 'client_id':'xxxx','client_secret':'xxxx'}" />

            string Json = Microsoft.WindowsAzure.CloudConfigurationManager.GetSetting("idealistaJson");
            if (String.IsNullOrEmpty(Json))
                throw new ConfigurationErrorsException("Idealista configuration not found");
            Configuration = JsonConvert.DeserializeObject<ConfigurationIdealista>(Json);

           
            catch (Exception)
            {

                throw;
            }
        }

    }
    /// <summary>
    /// Generic configurations class
    /// </summary>
    public  class ConfigurationIdealista
    {
        [JsonProperty("tokenurl")]
        public string TokenUrl { get; set; }


        [JsonProperty("basic_url")]
        public string Basic_url { get; set; }

        [JsonProperty("client_id")]
        public string Client_id { get; set; }

        [JsonProperty("client_secret")]
        public string Client_secret { get; set; }

       
    }
    /// <summary>
    /// lists of api methods
    /// </summary>
    public enum Method
    {
        GET = 3,
        POST = 0,
        PUT = 1,
        DELETE = 2
    }
    #endregion

    /// <summary>
    /// Menage api comunications in real time
    /// </summary>
    public class IdealistaApiController
    {

        /// <summary>
        /// Menage login and token with Oauth 2 
        /// </summary>
        /// <param name="client">client to use </param>
        /// <returns></returns>
        private static async Task<TokenAndConfigurationIdealista> GetElibilityToken(HttpClient client)
        {
            try
            {

                //get configuration from config local or cloud
                string Json = Microsoft.WindowsAzure.CloudConfigurationManager.GetSetting("idealistaJson");
                if (String.IsNullOrEmpty(Json))
                    throw new ConfigurationErrorsException("Idealista configuration not found");
                ConfigurationIdealista configuration = JsonConvert.DeserializeObject<ConfigurationIdealista>(Json);



                string grant_type = "client_credentials";

                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(configuration.Client_id+":"+ configuration.Client_secret);
                var basic= System.Convert.ToBase64String(plainTextBytes);

                
                client.DefaultRequestHeaders.Add("Authorization", "Basic " + basic); 

               
                var form = new Dictionary<string, string>
            {
                {"grant_type", grant_type},
                {"client_id", configuration.Client_id},
                {"client_secret", configuration.Client_secret}
            };

                string url = configuration.TokenUrl
                +"?";
                foreach (var item in form)
                {
                    url += item.Key + "=" + item.Value + "&";
                }

                url = url.TrimEnd('&');
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                var content = new StringContent(JsonConvert.SerializeObject(form), System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage tokenResponse = await client.PostAsync(url, content).ConfigureAwait(false);
                var jsonContent = await tokenResponse.Content.ReadAsStringAsync();
                Token tok = JsonConvert.DeserializeObject<Token>(jsonContent);
                tok.ExpiredDate= DateTime.Now.AddSeconds(tok.ExpiresIn);
                TokenAndConfigurationIdealista TokenAndConf = new TokenAndConfigurationIdealista()
                {
                    TokenGen = tok,
                    //Configuration = configuration
                };
                return TokenAndConf;
            }
            catch (Exception ex)
            {

                return null;
            }


        }

        /// <summary>
        /// Check if token is expired
        /// </summary>
        /// <param name="authorizeToken"></param>
        /// <returns></returns>
        public static bool IsTokenExpired(TokenAndConfigurationIdealista authorizeToken)
        {
            try
            {
                if (authorizeToken.TokenGen.ExpiredDate > DateTime.Now)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Idealista don't have refresh api, re-login
        /// </summary>
        /// <param name="authorizeToken"></param>
        /// <returns></returns>
        /// 
        public static async Task<TokenAndConfigurationIdealista> RefreshToken(HttpClient client,TokenAndConfigurationIdealista authorizeToken)
        {
            return await IdealistaApiController.GetElibilityToken(client).ConfigureAwait(false);
        }

        /// <summary>
        /// Generic api call, can bu used not only for idealista
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="AuthorizeToken">Token and Config</param>
        /// <param name="UrlApi">api url to call</param>
        /// <param name="Type">Method's Type: put,get,....</param>
        /// <param name="headerParams">Header's parameters</param>
        /// <param name="formParams">Form's parameters</param>
        /// <param name="toJsonObject">Form's parameters from json obj</param>
        /// <param name="retry">if is 0 retry the call in case of error  with login(if HttpStatusCode.Unauthorized,could be expired token) </param>
        /// <returns></returns>
        public static async Task<T> GenericCall<T>(TokenAndConfigurationIdealista AuthorizeToken, string UrlApi, Method Type, Dictionary<string, string> headerParams, Dictionary<string, string> formParams, Object toJsonObject = null, int retry = 0)
        {

            // Initialization.  
            string responseObj = string.Empty;
            string headers = "";

            try
            {

                T ret;
                // HTTP GET.  
                using (var client = new HttpClient())
                {
                    if (AuthorizeToken == null || AuthorizeToken.TokenGen == null || AuthorizeToken.TokenGen.ExpiredDate < DateTime.Now)
                    {
                        var NewToken = await IdealistaApiController.GetElibilityToken(client).ConfigureAwait(false);
                        AuthorizeToken.TokenGen = NewToken.TokenGen;
                    }
                    // Initialization  
                    string authorization = AuthorizeToken.TokenGen.AccessToken;

                    // Setting Authorization.  
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
                    foreach (var item in headerParams)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                        headers += $"Key:{item.Key} Value:{item.Value};";
                    }

                    
                    // Setting content type.  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Initialization.  
                    HttpResponseMessage response = new HttpResponseMessage();
                    StringContent content = null;
                    if ((Type == Method.GET || Type == Method.DELETE) && (formParams != null && formParams.Count > 0))
                    {
                        UrlApi += "?";
                        foreach (var item in formParams)
                        {
                            UrlApi += item.Key + "=" + item.Value + "&";
                        }
                        UrlApi.Remove(UrlApi.Length - 1);
                    }


                    if (Type != Method.GET && Type != Method.DELETE && toJsonObject == null)
                        content = new StringContent(JsonConvert.SerializeObject(formParams), System.Text.Encoding.UTF8, "application/json");

                    if (Type != Method.GET && Type != Method.DELETE && toJsonObject != null)
                        content = new StringContent(JsonConvert.SerializeObject(toJsonObject, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }), System.Text.Encoding.UTF8, "application/json");

                    //for logging

                    var SendEl = $", UrlApi: {UrlApi} " + (content != null ? (",json:" + content.ReadAsStringAsync().Result) : "" + $",headers:{headers}");
                    // call by type
                    switch (Type)
                    {
                        case Method.GET:
                            response = await client.GetAsync(UrlApi).ConfigureAwait(false);
                            break;
                        case Method.POST:
                            response = await client.PostAsync(UrlApi, content).ConfigureAwait(false);
                            break;
                        case Method.PUT:
                            response = await client.PutAsync(UrlApi, content).ConfigureAwait(false);
                            break;
                        case Method.DELETE:
                            response = await client.DeleteAsync(UrlApi).ConfigureAwait(false);
                            break;
                        default:
                            break;
                    }



                    // Verification  
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading Response.  
                        string resultContent = response.Content.ReadAsStringAsync().Result;


                        ret = JsonConvert.DeserializeObject<T>(resultContent);

                        if (ret is GeneralReturn)
                        {
                            ((GeneralReturn)(object)ret).message += " StatusCode:" + response.StatusCode + " ResultData: " + resultContent + "</br> SentData: " + SendEl + "</br>";
                        }

                        return ret;
                    }
                    else
                    {
                        // if is a auth problems and retry (happens with idealista)

                        if ((response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.BadRequest) && retry < 1)
                        {
                            System.Threading.Thread.Sleep(1000);
                            AuthorizeToken.TokenGen.ExpiredDate = DateTime.Now.AddDays(-1);
                            return await GenericCall<T>(AuthorizeToken, UrlApi, Type, headerParams, formParams, toJsonObject, 1);
                        }
                        try
                        {
                            var res = response.Content.ReadAsStringAsync().Result;
                            ret = JsonConvert.DeserializeObject<T>(res);
                            // for logging
                            if (ret is GeneralReturn)
                            {
                                ((GeneralReturn)(object)ret).message += " StatusCode:" + response.StatusCode + " ResultData: " + res + "</br> SentData: " + SendEl + "</br>";
                            }
                            return ret;
                        }
                        catch (Exception ex)
                        {

                            throw new HttpRequestException("Status:" + response.StatusCode.ToString() + " " + response.ReasonPhrase + " ex:" + ex.ToString());
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// For Retriving all properties we need a special call for grouping the properties
        /// </summary>
        /// <param name="authorizeToken">Token and configurazione</param>
        /// <param name="feedKeyAgency">idealista client code</param>
        /// <param name="retry">if 0 retry one time </param>
        /// <returns></returns>
        public static async Task<PropertiesReturn> RetriveAllProperties(TokenAndConfigurationIdealista authorizeToken,String feedKeyAgency,int retry=0 )
        {

            // Initialization.  
            string responseObj = string.Empty;

            try
            {

                PropertiesReturn ret = null;
                // HTTP GET.  
                using (var client = new HttpClient())
                {
                    if (authorizeToken == null || authorizeToken.TokenGen == null || authorizeToken.TokenGen.ExpiredDate< DateTime.Now)
                    {
                         var NewToken = await IdealistaApiController.GetElibilityToken(client).ConfigureAwait(false);
                        authorizeToken.TokenGen = NewToken.TokenGen;
                    }
                    // Initialization  
                    string authorization = authorizeToken.TokenGen.AccessToken;

                    // Setting Authorization.  
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authorization);
                    client.DefaultRequestHeaders.Add("feedKey", feedKeyAgency); //codice agenzia idealista

                    // Setting Base address.  
                    //client.BaseAddress = new Uri(authorizeToken.Configuration.CalcoloMutoUrl);

                    // Setting content type.  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Initialization.  
                    HttpResponseMessage response = new HttpResponseMessage();
                    //setting page size, the biggest one in this case
                    var form = new Dictionary<string, string>
            {
                { "page", "1"},
                { "size", "100" }                
            };

                    string url = TokenAndConfigurationIdealista.Configuration.Basic_url + "properties"
                + "?";
                    foreach (var item in form)
                    {
                        url += item.Key + "=" + item.Value + "&";
                    }

                    url = url.TrimEnd('&');

                    var content = new StringContent(JsonConvert.SerializeObject(form), System.Text.Encoding.UTF8, "application/json");
                      // first call
                    response = await client.GetAsync(url).ConfigureAwait(false);

                    // Verification  
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading Response.  
                        string resultContent = response.Content.ReadAsStringAsync().Result;
                      
                        try
                        {
                            ret= JsonConvert.DeserializeObject<PropertiesReturn>(resultContent);
                            //call for all pages
                            for (int page = ret.page.number; page < (ret.page.total); page++)
                            {
                                url = TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + "?page=" + (page+1) + "&size=100";
                                response = await client.GetAsync(url).ConfigureAwait(false);
                                if (response.IsSuccessStatusCode)
                                {
                                    resultContent = response.Content.ReadAsStringAsync().Result;
                                    var retExtra = JsonConvert.DeserializeObject<PropertiesReturn>(resultContent);
                                   //grouping
                                    if (retExtra != null)
                                        ret.properties.AddRange(retExtra.properties);

                                }
                            }
                        }
                        catch (Exception ex1)
                        {
                            throw ex1;

                        }
                        return ret;
                    }
                    else
                    {
                        // retry if login problem and retry=0 or <1
                        if (response.StatusCode== HttpStatusCode.Unauthorized && retry<1)
                        {
                            authorizeToken.TokenGen.AccessToken = null;
                            return await RetriveAllProperties(authorizeToken, feedKeyAgency, 1);
                        }
                        throw new HttpRequestException(response.ReasonPhrase);
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


       

        #region Idealista  Methods
        public static NewModPropertyReturn NewProperty(TokenAndConfigurationIdealista AuthorizeToken,string FeedKey,Property Prop)
        {
            return GenericCall<NewModPropertyReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties", Method.POST, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>(),Prop).GetAwaiter().GetResult();
        }

        public static NewModPropertyReturn UpdateProperty(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey,Property Prop)
        {
            return GenericCall<NewModPropertyReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{Prop.propertyId}", Method.PUT, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>(),Prop).GetAwaiter().GetResult();
        }

        public static OpPropertyReturn DeactivateProperty(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, int PropertyId)
        {
            return GenericCall<OpPropertyReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{PropertyId.ToString()}/deactivate", Method.POST, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>()).GetAwaiter().GetResult();
        }


        public static PropertyReturn FindProperty(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey,int PropertyId)
        {
            return GenericCall<PropertyReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{PropertyId}", Method.GET, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>() { { "propertyId", PropertyId.ToString() } }).GetAwaiter().GetResult();
        }
        public static OpPropertyReturn ActivateDeactivateProperty(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, int PropertyId,bool Activate)
        {
            var postUrl= Activate? "reactivate":"deactivate";            
            return GenericCall<OpPropertyReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{PropertyId}/{postUrl}", Method.POST, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>() { { "propertyId", PropertyId.ToString() } }).GetAwaiter().GetResult();
        }


        public static OpImageReturn NewImage(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId,Image Img)
        {
            return GenericCall<OpImageReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{PropertyId}/images", Method.POST, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>(),Img).GetAwaiter().GetResult();
        }

        public static ImagesReturn AllImages(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId)
        {
            return GenericCall<ImagesReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{PropertyId}/images", Method.GET, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>()).GetAwaiter().GetResult();
        }

        public static ImageReturn FindImage(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId, string ImageId)
        {
            return GenericCall<ImageReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{PropertyId}/images/{ImageId}", Method.GET, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>()).GetAwaiter().GetResult();
        }

        public static GeneralReturn DeleteImage(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId, string ImageId)
        {
            return GenericCall<GeneralReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{PropertyId}/images/{ImageId}", Method.DELETE, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>()).GetAwaiter().GetResult();
        }

        public static GeneralReturn UpdateImage(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId, string ImageId, ImageUpdate ImgUpdate)
        {
            return GenericCall<GeneralReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{PropertyId}/images/{ImageId}", Method.PUT, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>(),ImgUpdate).GetAwaiter().GetResult();
        }


        public static OpContactReturn NewContact(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, Contact Cont)
        {
            return GenericCall<OpContactReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "contacts" , Method.POST, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>(), Cont).GetAwaiter().GetResult();
        }


        public static GeneralReturn NewVT(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId, String VTUrl)
        {
            return GenericCall<OpImageReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{PropertyId}/virtualtours", Method.POST, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>(),new { url = VTUrl }).GetAwaiter().GetResult();
        }

        public static VTsReturn AllVTs(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId)
        {
            return GenericCall<VTsReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{PropertyId}/virtualtours", Method.GET, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>()).GetAwaiter().GetResult();
        }

        public static GeneralReturn DeactivateVT(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, String PropertyId,  String VTUrl)
        {
        
            return GenericCall<OpPropertyReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "properties" + $"/{PropertyId}/virtualtours/deactivate", Method.POST, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>() { { "propertyId", PropertyId.ToString() } }, new { url = VTUrl }).GetAwaiter().GetResult();
        }

        public static FindContactReturn FindContact(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string ContactId)
        {
            return GenericCall<FindContactReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "contacts" + $"/{ContactId}", Method.GET, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>()).GetAwaiter().GetResult();
        }
        public static OpContactReturn UpdateContact(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string ContactId,  Contact Cont)
        {
            return GenericCall<OpContactReturn>(AuthorizeToken, TokenAndConfigurationIdealista.Configuration.Basic_url + "contacts" + $"/{ContactId}", Method.PUT, new Dictionary<string, string>() { { "feedKey", FeedKey } }, new Dictionary<string, string>(),Cont).GetAwaiter().GetResult();
        }

        #endregion


    }
}
