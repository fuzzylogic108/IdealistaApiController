# IdealistaApiController
## .net Framework 4.7 Api Conjtroller for idealista Partner Api (0.1.0-Beta)

IdealistaApiController implement th Partner Api for idealista, in the main parts with all the classes and the structures for menage it.
- Defines data classes for the exchange of data (the jsons of the api)
- Menage configuration
- Implement and mantains the Oauth 2.0 logic for the authentications
- Implement the main api

## Oauth 2.0 logic

Menage login and token with Oauth 2:
```  
private static async Task<TokenAndConfigurationIdealista> GetElibilityToken(HttpClient client)
```

Check if token is expired:
```  
public static bool IsTokenExpired(TokenAndConfigurationIdealista authorizeToken)
```

It's a fake refresh, Idealista don't have refresh api, re-login
```  
public static async Task<TokenAndConfigurationIdealista> RefreshToken(HttpClient client,TokenAndConfigurationIdealista authorizeToken)
```

## GenericCall

This function is the heart of the controllorer this function with few modifications can be used for all api call.

```  
 public static async Task<T> GenericCall<T>(TokenAndConfigurationIdealista AuthorizeToken, string UrlApi, Method Type, Dictionary<string, string> headerParams, Dictionary<string, string> formParams, Object toJsonObject = null, int retry = 0)
```

**Parameters**

| Name Par | Description |
| ------ | ------ |
| T | Return type |
| AuthorizeToken | Token and Config class |
| UrlApi | api url to call |
| Type | Method's Type: put,get,.... |
| formParams | Form's parameters |
| toJsonObject | Form's parameters from json obj |
| retry | if is 0 retry the call in case of error  with login(if HttpStatusCode.Unauthorized,could be expired token) |

## Functions

###RetriveAllProperties

For Retriving all properties we need a special call for grouping the properties

```  
 public static async Task<PropertiesReturn> RetriveAllProperties(TokenAndConfigurationIdealista authorizeToken,String feedKeyAgency,int retry=0 )
```

**Parameters**

| Name Par | Description |
| ------ | ------ |
| authorizeToken | Token and configuration |
| feedKeyAgency | Idealista client code |
| retry | if 0 retry one time |

###NewProperty

```  
public static NewModPropertyReturn NewProperty(TokenAndConfigurationIdealista AuthorizeToken,string FeedKey,Property Prop)
```

###UpdateProperty

```  
 public static NewModPropertyReturn UpdateProperty(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey,Property Prop)
```
###DeactivateProperty

```  
public static OpPropertyReturn DeactivateProperty(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, int PropertyId)
```
###FindProperty

```  
public static PropertyReturn FindProperty(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey,int PropertyId)
```
###ActivateDeactivateProperty

```  
public static OpPropertyReturn ActivateDeactivateProperty(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, int PropertyId,bool Activate)
```
###NewImage

```  
public static OpImageReturn NewImage(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId,Image Img)
```
###AllImages

```  
public static ImagesReturn AllImages(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId)
```
###FindImage

```  
public static ImageReturn FindImage(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId, string ImageId)
```

###FindImage

```  
public static ImageReturn FindImage(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId, string ImageId)
```
###DeleteImage

```  
public static GeneralReturn DeleteImage(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId, string ImageId)
```
###UpdateImage

```  
public static GeneralReturn UpdateImage(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId, string ImageId, ImageUpdate ImgUpdate)
```
###NewContact

```  
public static OpContactReturn NewContact(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, Contact Cont)
```
###NewVT

```  
public static GeneralReturn NewVT(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId, String VTUrl)
```
###AllVTs

```  
public static VTsReturn AllVTs(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string PropertyId)
```
###DeactivateVT

```  
 public static GeneralReturn DeactivateVT(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, String PropertyId,  String VTUrl)
```
###FindContact

```  
public static FindContactReturn FindContact(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string ContactId)
```
###UpdateContact

```  
public static OpContactReturn UpdateContact(TokenAndConfigurationIdealista AuthorizeToken, string FeedKey, string ContactId,  Contact Cont)
```


