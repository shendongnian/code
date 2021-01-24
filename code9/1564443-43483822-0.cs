    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace teste {
    	class MainClass {
    		public static void Main(string[] args) {
    
    			var jsonString = @"{'consumerId':56704292158, 'categoryId':1, 'categoryDescription': 'Pessoa', 'firstName':'FN','lastName':'Last Name','fiscalDocuments':[{'fiscalDocument':{'documentType':'Brasil: nº CPF','cpf':199999992}}],'gender':'M','emailAddress':'r * ***@*.com','optIns':[{'optIn':{'brandName':'consul','acceptanceStatus':false}},{'optIn':{'brandName':'brastemp','acceptanceStatus':true}}],'communicationData':[{'communicationInfo':{'addressId':'2****03','phoneNumbers':[{'phoneNumber':{'phoneType':'mobilePhone','phoneNumber':5555555555}}],'streetAddress':'ANY STREET','streetNumber':123,'streetComplement':null,'streetDistrict':'ANY TOWN','cityName':'ANY CITY','stateCode':'XX','zipCode':'12345','locationReferences':[{'locationReference':'Mercado'}],'countryCode':'ZZ'}},{'communicationInfo':{'addressId':'2.563244','phoneNumbers':[{'phoneNumber':{'phoneType':'mobilePhone','phoneNumber':5555555555}},{'phoneNumber':{'phoneType':'homePhone','phoneNumber':555555555}}],'streetAddress':'ANY STREET','streetNumber':123,'streetComplement':'CASA','streetDistrict':'ANY TOWN','cityName':'ANY CITY','stateCode':'XX','zipCode':'12345','locationReferences':[{'locationReference':'Ao lado do deposito lua nova'}],'countryCode':'ZZ'}}]}";
    
    			JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings {
    				NullValueHandling = NullValueHandling.Ignore,
    				MissingMemberHandling = MissingMemberHandling.Ignore
    			};
    
    			Pessoa pessoa = JsonConvert.DeserializeObject<Pessoa>(jsonString, jsonSerializerSettings);
    
    			Console.WriteLine(pessoa.FirstName);
    			Console.WriteLine(pessoa.LastName);
    		}
    	}
    
    	public class Pessoa {
    		public long ConsumerId { get; set; }
    		public int CategoryId { get; set; }
    		public string CategoryDescription { get; set; }
    		public string FirstName { get; set; }
    		public string LastName { get; set; }
    		public List<FiscalDocumentData> FiscalDocuments { get; set; }
    		public string Gender { get; set; }
    		public string EmailAddress { get; set; }
    		public List<OptInData> OptIns { get; set; }
    		public List<CommunicationData> CommunicationData { get; set; }
    	}
    
    	public class OptInData {
    		public OptInInfo OptIn { get; set; }
    	}
    
    	public class OptInInfo {
    		public string BrandName { get; set; }
    		public bool AcceptanceStatus { get; set; }
    	}
    
    	public class FiscalDocumentData {
    		public FiscalDocumentInfo FiscalDocument {get; set; }
    	}
    
    	public class FiscalDocumentInfo {
    		public string DocumentType { get; set; }
    		public long Cpf { get; set; }
    	}
    
    	public class CommunicationData {
    		public CommunicationInfo CommunicationInfo { get; set; }
    	}
    
    	public class CommunicationInfo {
    		public string AddressId { get; set; }
    		public List<PhoneInfo> PhoneNumbers { get; set; }
    		public string StreetAddress { get; set; }
    		public int StreetNumber { get; set; }
    		public string StreetComplement { get; set; }
    		public string StreetDistrict { get; set; }
    		public string CityName { get; set; }
    		public string StateCode { get; set; }
    		public string ZipCode { get; set; }
    		public List<Reference> LocationReferences { get; set; }
    		public string CountryCode { get; set; }
    	}
    
    	public class Reference {
    		public string LocationReference { get; set; }
    	}
    
    	public class PhoneInfo {
    		public PhoneNumberInfo PhoneNumber { get; set; }
    	}
    
    	public class PhoneNumberInfo {
    		public string PhoneType { get; set; }
    		public long PhoneNumber { get; set; }
    	}
    }
