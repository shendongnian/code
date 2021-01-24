    namespace testjson
    {
        public class Datum
        {
            public string OfficeID { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string userName { get; set; }
            public string birthdate { get; set; }
            public string emailEmployee { get; set; }
            public string functionCategory { get; set; }
        }
    
        public class RootObject
        {
            public List<Datum> data { get; set; }
            public string IsError { get; set; }
            public string ErrorMessage { get; set; }
            public string ResponseData { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                string jString= @"{ 'data':[{'officeID':'L4UFJw8GpQPg8iryJlHgeQ8L9wvGaGMozF33HxYrouY=','firstName':'R6UELs10\/qC+e9Iej1Sfh44H53bC1iez1FX9UoBdmL4=','lastName':'dZh5xGkYre\/Qjv\/d8PnYE+0F+YB\/pACDsOhnbT1vC7I=','userName':'oJ9SUemStHW6XGJrRSgQJxBUxHIWKejj3yVjbxiNHH8=','birthdate':'386TvajxJiPRXU4UT5OIqH3jmgSqqmv+n09tqxR9458=','email':'1kuUiACYGwkHseT32NfCbb6QH68Mq09ur5LdBo2SzUhdD6mWQjN9leekZrcZVmzcVCfSA4iEgTIspS3j8naYjg==','functionCategoryID':'79kSmrt7HmEYhqBd+NGd8la3NRVkSaeU+9rx7ri\/jG0='},{'officeID':'Ue86sZNLpM0dZXDBbAw4bgpg36te\/Uym3j\/7c\/RK6So=','firstName':'OK6EiNwnB7Ixb25ua62Us1sCMQ3VlGrjAawtU5pamFk=','lastName':'OK6EiNwnB7Ixb25ua62Us1sCMQ3VlGrjAawtU5pamFk=','userName':'OK6EiNwnB7Ixb25ua62Us1sCMQ3VlGrjAawtU5pamFk=','birthdate':'CgQqdhV3+ZnCSwN6+o9b0kP8i107pgERzWYolkp6dWA=','email':'GHm0Re5AMOEXVjmeuscd5JUAswdDQsvqxzzolEXZ75g=','functionCategoryID':'uIPaVTdcTsORfPMM9kjOdoB5Mf5bZShp2eDrt0bhJA8='},{'officeID':'TQ8MQHfCxpu4XMAYJpDcJ9JIGJ\/oZdZTwirC3O9RoRQ=','firstName':'8PIIK6lsX4q9l39oS+ZIlkpKyhnisTVI3d2qa9Rk7IU=','lastName':'8PIIK6lsX4q9l39oS+ZIlkpKyhnisTVI3d2qa9Rk7IU=','userName':'8PIIK6lsX4q9l39oS+ZIlkpKyhnisTVI3d2qa9Rk7IU=','birthdate':'CgQqdhV3+ZnCSwN6+o9b0kP8i107pgERzWYolkp6dWA=','email':'5EID57UhzVapKSu0hPdlU8++ScgjslS5qiqkNGk5Urk=','functionCategoryID':'uIPaVTdcTsORfPMM9kjOdoB5Mf5bZShp2eDrt0bhJA8='},{'officeID':'87Qn9VDRcho3E9SpkkmN3Voow4xbVRrP6Eg1e9q+LTk=','firstName':'j3PjfbjwOyP\/s2kiXWUrFQT33985hJhymjSgyvVWD88=','lastName':'j3PjfbjwOyP\/s2kiXWUrFQT33985hJhymjSgyvVWD88=','userName':'j3PjfbjwOyP\/s2kiXWUrFQT33985hJhymjSgyvVWD88=','birthdate':'aAYSiKoBVvMZ\/x7zZ3fKW8SLDxSNzSguQ2VtpFqn1\/g=','email':'cnHQfIfyGbaSGW9aVPCPkpZ0fxtN2vH8\/Rmhfa61GpU=','functionCategoryID':'uIPaVTdcTsORfPMM9kjOdoB5Mf5bZShp2eDrt0bhJA8='},{'officeID':'fJrhmHvZkTb909xEuy9GBDFTzwmBqOAzJMSdv\/z2NeY=','firstName':'R6UELs10\/qC+e9Iej1Sfh44H53bC1iez1FX9UoBdmL4=','lastName':'dZh5xGkYre\/Qjv\/d8PnYE+0F+YB\/pACDsOhnbT1vC7I=','userName':'u2Q+5N0qfGXguAAXPrjfg27bKcsfn9kmuFirw3D+ESE=','birthdate':'aAYSiKoBVvMZ\/x7zZ3fKW8SLDxSNzSguQ2VtpFqn1\/g=','email':'acpGLJU7viDD8bvDP6cehUtKu4jsu0S7NocWzWI5HsU=','functionCategoryID':'uIPaVTdcTsORfPMM9kjOdoB5Mf5bZShp2eDrt0bhJA8='},{'officeID':'+F8IDemrdYxhfhZRffkcfpC8XRS13jl1zee8jCYZo+k=','firstName':'R6UELs10\/qC+e9Iej1Sfh44H53bC1iez1FX9UoBdmL4=','lastName':'dZh5xGkYre\/Qjv\/d8PnYE+0F+YB\/pACDsOhnbT1vC7I=','userName':'ZaBSv\/5EzxsxaPLVex1m3s0FZ5AAsPHejn1N7qe5lHo=','birthdate':'aAYSiKoBVvMZ\/x7zZ3fKW8SLDxSNzSguQ2VtpFqn1\/g=','email':'dluwI6UQb8M\/eRyaw0YHfX2+kfK2Q1HebrBoQP9Uths=','functionCategoryID':'LwtYJQvWw97ejLbYWRFJn+S5sVKVXvzDXgYat4Le5zQ='},{'officeID':'7jqdChVFIQt5cdXznM5Qmv1EOqgfpi580OHek1L2FVA=','firstName':'R6UELs10\/qC+e9Iej1Sfh44H53bC1iez1FX9UoBdmL4=','lastName':'dZh5xGkYre\/Qjv\/d8PnYE+0F+YB\/pACDsOhnbT1vC7I=','userName':'iShpHaczQ4RtkHVvXmv3nRv8m59qppApLQ99Civ1QlU=','birthdate':'aAYSiKoBVvMZ\/x7zZ3fKW8SLDxSNzSguQ2VtpFqn1\/g=','email':'pq9yUcG+VK5xlHpemKm9B7sE7PxlCdCkFpzhIy\/8k8g=','functionCategoryID':'LwtYJQvWw97ejLbYWRFJn+S5sVKVXvzDXgYat4Le5zQ='},{'officeID':'NkMDOXBeKbSt2jbZNeVaAJaj2V6LUyN9iHVpq4z9YRc=','firstName':'R6UELs10\/qC+e9Iej1Sfh44H53bC1iez1FX9UoBdmL4=','lastName':'dZh5xGkYre\/Qjv\/d8PnYE+0F+YB\/pACDsOhnbT1vC7I=','userName':'GWl7tJfGtL0VXgL2Jn93KO2j4lTHl7vuEpjS5dvrn0E=','birthdate':'aAYSiKoBVvMZ\/x7zZ3fKW8SLDxSNzSguQ2VtpFqn1\/g=','email':'ZLGkTKft82pwTnRJKFWPkE3BFT4WVPt2Qd1P9Og387A=','functionCategoryID':'b3Wl2KsdFOPDVfsrwg2Y347qGc8PM5Yd8UPS+hY7xSk='}],'IsError':'false','ResponsData':'Success'}";
               var yourObject =  JsonConvert.DeserializeObject<RootObject>(jString);
            }
       
