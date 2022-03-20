# API Key Implementation for ASP Net Core
## API Key Middleware
Contained in this repository is an example of implementing API Key Authentication through middleware. However this example applies the API Key Authentication to all of the API actions.
<br/>
![API Key Attribute Definition](./assets/images/Screenshot_Middleware.png)
<br/>
## API Key Action/Class Attribute
Contained in this repository is an example of implementing API Key Authentication through attributes. This attribute can be applied at both the class and method levels as `[APIKey]`.
<br/>
![API Key Attribute Definition](./assets/images/Screenshot_Attribute.png)
![API Key Attribute on Class](./assets/images/Screenshot_Class.png)
![API Key Attribute on Action](./assets/images/Screenshot_Action.png)
<br/>
## Definition of Single API Key
The API Key is defined in the `appsettings.json` file as `APIKey`.
<br/>
![Definition of API Key](./assets/images/Screenshot_APIKey.png)
<br/>
## Example API Request
![Postman Request](./assets/images/Screenshot_Request.png)
