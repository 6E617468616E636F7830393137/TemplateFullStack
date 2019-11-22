= = = = = = = = = = = = = = = = = = = = = = = 
 {Dot} Net Solution for Framework and Core
= = = = = = = = = = = = = = = = = = = = = = =

DESCRIPTION: This is a solution for a full stack solution containing projects that are formatted for both .Net Framework and .Net Core. These are emerging technologies that will ultimately result in a new development family called .Net to be released in November 2020. November 2019 demostrates a possible situation of either following a holding pattern, and stay with the current technologies until next year or working with both current .Net families in parallel, Core and Framework.  The first major advantage in using both technologies in parallel in adopting new implementations and seeing how various packages work within the two different frameworks. The major packages for the development paradigm here will be Autofac (Presentation Layer), Log4Net (Business and Presentation and Testing Layers), Entity Framework (Entities, Data Access, Business, and Presentation layers), and web request calls (personalized Dll for making various web calls to URL resources).  

LAYERS: The soltuion consisits of multiple n-teir layers separated by the corresponding .Net technology in use.  In this solution, there will be 3 different tiers consisiting of 7 different layers containing 2 different .Net technologies in each layer.  Resulting in a total of 14 differnt projects total.

- - - - - - 
 Tier 0: 
- - - - - -

ASSEMBLIES
 └─> Core 
 └─> Framework

ENTITIES
 └─> Core 
 └─> Framework
 
MODELS
 └─> Core 
 └─> Framework

- - - - - - 
Tier 1: 
- - - - - -

DATA
 └─> Core 
 └─> Framework
 
SERVICES
 └─> Core 
 └─> Framework

- - - - - - 
Tier 2: 
- - - - - -

BUSINESS

- - - - - -
Tier 3: 
- - - - - -

PRESENTATION
 └─> Core 
 └─> Framework

TESTS
 └─> Core 
 └─> Framework
 
 NUGET PACKAGES: Packages are needed in order to build out structures that supports interface dependency injection.  The template manages the following packages on the following solutions:
 
 ENTITIES - Focused on database context.  Will need to run scaffolding commands from Package Management Console to bind the database context to its programmatic entity structure.
 └─> Core : 
	└─>	Command : Install-Package Microsoft.EntityFrameworkCore.SqlServer
	└─>	Command : Install-Package Microsoft.EntityFrameworkCore.Tools
	└─>	Command : Scaffold-DbContext "Server=mvcdata.db.7888150.hostedresource.com;Database=mvcdata;persist security info=True;user id=<USER_ID>;password=<PASSWORD>;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Fortunes -Tables Messages
 └─> Framework :
 
 DATA - Accesses the database through the Entities layer.  
 └─> Core :
	└─>	Command : Install-Package Microsoft.EntityFrameworkCore.Tools
 └─> Framework :
 
 PRESENTATION
 └─> Core :
 	└─>	Command : Install-Package Autofac.Extensions.DependencyInjection
	└─>	Command : Install-Package Swashbuckle.AspNetCore
	└─>	Command : Install-Package Microsoft.AspNetCore.StaticFiles
	└─>	Command : Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design
 └─> Framework :

TESTS
 └─> Core :
 └─> Framework :