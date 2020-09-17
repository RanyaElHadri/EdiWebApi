using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using indice.Edi.Serialization;

namespace WebApplication
{
    /// <summary>
    /// Advance Ship Notice 856
    /// </summary>
    public class AdvanceShipNotice_856
    {
        internal readonly object item;

        #region ISA and IEA
        [EdiValue("9(2)", Path = "ISA/0", Description = "ISA01 - Authorization Information Qualifier")]
        public int AuthorizationInformationQualifier { get; set; }

        [EdiValue("X(10)", Path = "ISA/1", Description = "ISA02 - Authorization Information")]
        public string AuthorizationInformation { get; set; }

        [EdiValue("9(2)", Path = "ISA/2", Description = "ISA03 - Security Information Qualifier")]
        public string Security_Information_Qualifier { get; set; }

        [EdiValue("X(10)", Path = "ISA/3", Description = "ISA04 - Security Information")]
        public string Security_Information { get; set; }

        [EdiValue("9(2)", Path = "ISA/4", Description = "ISA05 - Interchange ID Qualifier")]
        public string ID_Qualifier { get; set; }

        [EdiValue("X(15)", Path = "ISA/5", Description = "ISA06 - Interchange Sender ID")]
        public string Sender_ID { get; set; }

        [EdiValue("9(2)", Path = "ISA/6", Description = "ISA07 - Interchange ID Qualifier")]
        public string ID_Qualifier2 { get; set; }

        [EdiValue("X(15)", Path = "ISA/7", Description = "ISA08 - Interchange Receiver ID")]
        public string Receiver_ID { get; set; }

        [EdiValue("9(6)", Path = "ISA/8", Format = "yyMMdd", Description = "I09 - Interchange Date")]
        [EdiValue("9(4)", Path = "ISA/9", Format = "HHmm", Description = "I10 - Interchange Time")]
        public DateTime Date { get; set; }

        [EdiValue("X(1)", Path = "ISA/10", Description = "ISA11 - Interchange Control Standards ID")]
        public string Control_Standards_ID { get; set; }

        [EdiValue("9(5)", Path = "ISA/11", Description = "ISA12 - Interchange Control Version Num")]
        public int ControlVersion { get; set; }

        [EdiValue("9(9)", Path = "ISA/12", Description = "ISA13 - Interchange Control Number")]
        public int ControlNumber { get; set; }

        [EdiValue("9(1)", Path = "ISA/13", Description = "ISA14 - Acknowledgement Requested")]
        public bool? AcknowledgementRequested { get; set; }

        [EdiValue("X(1)", Path = "ISA/14", Description = "ISA15 - Usage Indicator")]
        public string Usage_Indicator { get; set; }

        [EdiValue("X(1)", Path = "ISA/15", Description = "ISA16 - Component Element Separator")]
        public char? Component_Element_Separator { get; set; }

        [EdiValue("9(1)", Path = "IEA/0", Description = "IEA01 - Num of Included Functional Grps")]
        public int GroupsCount { get; set; }

        [EdiValue("9(9)", Path = "IEA/1", Description = "IEA02 - Interchange Control Number")]
        public int TrailerControlNumber { get; set; }

        #endregion

        public List<FunctionalGroup> Groups { get; set; }

        [EdiGroup]
        public class FunctionalGroup
        {

            [EdiValue("X(2)", Path = "GS/0", Description = "GS01 - Functional Identifier Code")]
            public string FunctionalIdentifierCode { get; set; }

            [EdiValue("X(15)", Path = "GS/1", Description = "GS02 - Application Sender's Code")]
            public string ApplicationSenderCode { get; set; }

            [EdiValue("X(15)", Path = "GS/2", Description = "GS03 - Application Receiver's Code")]
            public string ApplicationReceiverCode { get; set; }

            [EdiValue("9(8)", Path = "GS/3", Format = "yyyyMMdd", Description = "GS04 - Date")]
            [EdiValue("9(4)", Path = "GS/4", Format = "HHmm", Description = "GS05 - Time")]
            public DateTime Date { get; set; }

            [EdiValue("9(9)", Path = "GS/5", Format = "HHmm", Description = "GS06 - Group Control Number")]
            public int GroupControlNumber { get; set; }

            [EdiValue("X(2)", Path = "GS/6", Format = "HHmm", Description = "GS07 Responsible Agency Code")]
            public string AgencyCode { get; set; }

            [EdiValue("X(2)", Path = "GS/7", Format = "HHmm", Description = "GS08 Version / Release / Industry Identifier Code")]
            public string Version { get; set; }

            public List<Order> Orders { get; set; }


            [EdiValue("9(1)", Path = "GE/0", Description = "97 Number of Transaction Sets Included")]
            public int TransactionsCount { get; set; }

            [EdiValue("9(9)", Path = "GE/1", Description = "28 Group Control Number")]
            public int GroupTrailerControlNumber { get; set; }
        }

        [EdiMessage]
        public class Order
        {
            #region Header Trailer


            [EdiValue("X(3)", Path = "ST/0", Description = "ST01 - Transaction set ID code")]
            public string TransactionSetCode { get; set; }

            [EdiValue("X(9)", Path = "ST/1", Description = "ST02 - Transaction set control number")]
            public string TransactionSetControlNumber { get; set; }

            [EdiValue(Path = "SE/0", Description = "SE01 - Number of included segments")]
            public int SegmentsCouts { get; set; }

            [EdiValue("X(9)", Path = "SE/1", Description = "SE02 - Transaction set control number (same as ST02)")]
            public string TrailerTransactionSetControlNumber { get; set; }
            #endregion

            [EdiValue("X(2)", Path = "BSN/0", Description = "BSN01 - Trans. Set Purpose Code")]
            public string TransSetPurposeCode { get; set; }

            [EdiValue("9(6)", Path = "BSN/1", Description = "BSN02 - Shipment Identification")]
            public string ShipmentIdentification { get; set; }

            [EdiValue("9(8)", Path = "BSN/2", Format = "yyyyMMdd", Description = "BSN03 -  Date")]
            [EdiValue("9(6)", Path = "BSN/3", Format = "HHmmss", Description = "BSN04 - Time")]
            public DateTime PurchaseOrderDate { get; set; }
            [EdiValue("9(4)", Path = "BSN/4", Description = "BSN05 - Hierarchical Structure Code")]

            public string HierarchicalStructureCode { get; set; }



            [EdiValue("9(1)", Path = "HL/0", Description = "HL01 - Hierarchical ID Number")]
            public string HierarchicalIDNum { get; set; }


            [EdiValue(Path = "HL/1", Description = "HL02 - Hierarchical Level Code")]
            public string HierarchicalLevel { get; set; }


            [EdiValue("X(1)", Path = "HL/2", Description = "HL03 - Hierarchical ID Number")]
            public string HierarchicalIbe { get; set; }






            [EdiValue("X(3)", Path = "TD1/0", Description = "TD101 - Packaging Code")]
            public string PackagingCode { get; set; }

            [EdiValue("9(1)", Path = "TD1/1", Description = "TD102 - Lading Quantity")]
            public string LadingQuantity { get; set; }

            [EdiValue("X(2)", Path = "TD1/5", Description = "TD106 - Weight Qualifier")]

            public string WeightQualifier { get; set; }
            [EdiValue("X(6)", Path = "TD1/6", Description = "TD107 - Weight")]

            public string Weight { get; set; }
            [EdiValue("X(2)", Path = "TD1/7", Description = "TD108 - Unit or Basis for Measurement Code")]

            public string BasisMeasurementCode { get; set; }

            // ADD TD5


            [EdiValue("9(2)", Path = "TD5/1", Description = "TD102 - Lading Quantity")]
            public string AdingQuantity { get; set; }

            [EdiValue("X(4)", Path = "TD5/2", Description = "TD106 - Weight Qualifier")]

            public string WightQualifier { get; set; }
            [EdiValue("X(4)", Path = "TD5/4", Description = "TD107 - Weight")]



            [EdiValue(Path = "REF/0", Description = "REF01 - Reference Identification Qualifier IA – Vendor Number assigned by Carhartt")]
            public string ReferenceIdentificationQualifier { get; set; }

            [EdiValue("X(10)", Path = "REF/1", Description = "REF02 - Reference Identification")]
            public string ReferenceIdentification { get; set; }



            public List<HL2> HL2 { get; set; }

            public List<REF> REF { get; set; }

            public List<REF2> REF2 { get; set; }






            public List<N1> N1 { get; set; }
            public List<N11> N11 { get; set; }


            public List<N3> N3 { get; set; }


            public List<N4> N4 { get; set; }

            public List<N41> N41 { get; set; }
            public List<N42> N42 { get; set; }
            public List<N44> N44 { get; set; }
            public List<N45> N45 { get; set; }


            //   public List<Address> Addresses { get; set; }

            public List<OrderDetail> Items { get; set; }

        }




        /*     [EdiSegment, EdiSegmentGroup("DTM", SequenceEnd = "N4")]
             public class Address
             {

                 [EdiValue(Path = "DTM/0", Description = "DTM01 - Date/Time Qualifier")]
                 public string DateTimeQualifier { get; set; }

                 [EdiValue("9(8)", Path = "DTM/1", Format = "yyyyMMdd", Description = "DTM02 - Date format =CCYYMMDD")]
                 public DateTime Date { get; set; }





                 // ça affiche juste les 3 premiers N1 N3 N4 avec ce chemin x12_850.Groups[0].Orders[0].Addresses[0].   ... (par exp .AdressCode)

                 [EdiValue(Path = "N1/0", Description = "N101 - Address Code")]
                 public string AddressCode { get; set; }

                 [EdiValue(Path = "N1/1", Description = "N102 - Address Name")]
                 public string AddressName { get; set; }


                 [EdiValue(Path = "N3/0", Description = "N301 - Address Information")]
                 public string AddressInformation { get; set; }



                 [EdiValue(Path = "N4/0", Description = "N401 - City Name")]
                 public string CityName { get; set; }

                 [EdiValue(Path = "N4/1", Description = "N401 - City Name")]
                 public string CityName2 { get; set; }


                 [EdiValue(Path = "N4/2", Description = "N402 - Country Code")]
                 public string CountryCode { get; set; }
                 [EdiValue(Path = "N4/3", Description = "N401 - City Name")]
                 public string CityNam { get; set; }

                 [EdiValue(Path = "N4/4", Description = "N401 - City Name")]
                 public string CityNam2 { get; set; }


                 [EdiValue(Path = "N4/5", Description = "N402 - Country Code")]
                 public string Countode { get; set; }



                //  public List<N1> N1 { get; set; }
                  //  public List<N12> N12 { get; set; }

                    // public List<N1> N4 { get; set; }







             }*/
        [EdiSegment, EdiSegmentGroup("PRF", SequenceEnd = "CTT")]
        public class OrderDetail
        {
            [EdiValue("9(8)", Path = "PRF/0", Description = "PO101 - Order Line Number")]
            public string OrderLineNumber { get; set; }



            [EdiValue("9(8)", Path = "PRF/3", Description = "PO104 - Unit Price")]
            public decimal UnitPrice { get; set; }

            [EdiValue("9(1)", Path = "HL/0", Description = "HL01 - Hierarchical ID Number")]
            public string HierarchicalIDNum { get; set; }


            [EdiValue("9(1)", Path = "HL/1", Description = "HL03 - Hierarchical Level Code")]
            public string HierarchicalLevelCo { get; set; }

            [EdiValue("X(1)", Path = "HL/2", Description = "HL01 - Hierarchical ID Number")]
            public string HierarchicalIbe { get; set; }


            [EdiValue("9(1)", Path = "CTT/0", Description = "PO101 - Order Line Number")]
            public string OrderLineNumbe { get; set; }



            [EdiValue("9(2)", Path = "CTT/1", Description = "PO104 - Unit Price")]
            public string UnitPri { get; set; }






            public List<HL> HL { get; set; }









        }


        [EdiElement, EdiPath("HL/0")]
        public class HL
        {


            [EdiValue("9(1)", Path = "HL/0", Description = "HL01 - Hierarchical ID Number")]
            public string HierarchicalIDNum { get; set; }


            [EdiValue(Path = "HL/1", Description = "HL02 - Hierarchical Level Code")]
            public string HierarchicalLevel { get; set; }


            [EdiValue("X(1)", Path = "HL/2", Description = "HL03 - Hierarchical ID Number")]
            public string HierarchicalIbe { get; set; }
        }

        [EdiElement, EdiPath("HL/0")]
        public class HL2
        {


            [EdiValue("9(1)", Path = "HL/0", Description = "HL01 - Hierarchical ID Number")]
            public string HierarchicalIDNum { get; set; }


            [EdiValue(Path = "HL/1", Description = "HL02 - Hierarchical Level Code")]
            public string HierarchicalLevel { get; set; }


            [EdiValue("X(1)", Path = "HL/2", Description = "HL03 - Hierarchical ID Number")]
            public string HierarchicalIbe { get; set; }
        }





        [EdiElement, EdiPath("REF/0")]
        public class REF
        {


            [EdiValue(Path = "REF/0", Description = "REF01 - Reference Identification Qualifier IA – Vendor Number assigned by Carhartt")]
            public string ReferenceIdentificationQualifier { get; set; }




        }


        [EdiElement, EdiPath("REF/1")]
        public class REF2
        {

            [EdiValue("X(10)", Path = "REF/1", Description = "REF02 - Reference Identification")]
            public string ReferenceIdentification { get; set; }


        }










        [EdiElement, EdiPath("N1/0")]
        public class N1
        {
            [EdiValue(Path = "N1/0", Description = "N101 - Address Code")]
            public string AddressCode { get; set; }

        }


        [EdiElement, EdiPath("N1/1")]
        public class N11
        {

            [EdiValue(Path = "N1/1", Description = "N102 - Address Name")]
            public string AddressName { get; set; }
        }






        [EdiElement, EdiPath("N3/0")]
        public class N3
        {

            [EdiValue(Path = "N3/0", Description = "N301 - Address Information")]
            public string AddressInformation { get; set; }
        }






        [EdiElement, EdiPath("N4/0")]
        public class N4
        {
            [EdiValue(Path = "N4/0", Description = "N401 - City Name")]
            public string CityName2 { get; set; }







        }


        [EdiElement, EdiPath("N4/1")]
        public class N41
        {
            [EdiValue(Path = "N4/1", Description = "N402 - Country Code")]
            public string CountryCode { get; set; }

        }


        [EdiElement, EdiPath("N4/2")]
        public class N42
        {

            [EdiValue(Path = "N4/2", Description = "N401 - City Name")]
            public string CityNam { get; set; }


        }


        [EdiElement, EdiPath("N4/4")]
        public class N44
        {


            [EdiValue(Path = "N4/4", Description = "N401 - City Name")]
            public string CityNam2 { get; set; }

        }

        [EdiElement, EdiPath("N4/5")]
        public class N45
        {

            [EdiValue(Path = "N4/5", Description = "N402 - Country Code")]
            public string Countode { get; set; }

        }





        #region Edi Enumerations
        #endregion
    }
}
