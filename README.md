# InventoryDemo
Car Inventory Demo


1. Run Script in your database so it will generate schema data , Script can be found inside Database Script folder

2. Update Connectionstring in web.config

<connectionStrings><add name="CarsInventoryEntities" connectionString="metadata=res://*/Models.InventoryModel.csdl|res://*/Models.InventoryModel.ssdl|res://*/Models.InventoryModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=DESKTOP-F6CGRPG\SQLEXPRESS;initial catalog=CarsInventory;user id=sa;password=rupin;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" /></connectionStrings></configuration>
