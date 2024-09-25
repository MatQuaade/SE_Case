# SE_Case

This project contains two main parts, a micro service for handling Assets and a Gateway for handling external communication with the microservices.

To test a base flow of getting an asset through the Gateway follow these steps:
1. Boot up the AssetService application, and navigate to http://localhost:29945/swagger
2. Use the endpoint Asset/CreateFromList using the content of AssetMetadata-CreateMany.json to create a list of objects in the local database
3. Boot up the GatewayService, and navigate to http://localhost:7206/swagger
4. Use the endpoint Asset/GetAsset?assetId=ASSET001 either of the ids of the objects create in CreateFromList can be used
