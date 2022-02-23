dotnet ef dbcontext scaffold "Server=tcp:ibdbserver.database.windows.net,1433;Initial Catalog=ibdb;Persist Security Info=False;User ID=adminuser;Password=Admin1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
Scaffold-DbContext "Server=tcp:ibdbserver.database.windows.net,1433;Initial Catalog=ibdb;Persist Security Info=False;User ID=adminuser;Password=Admin1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
Scaffold-DbContext "Server=tcp:ibdbserver.database.windows.net,1433;Initial Catalog=ibdb;Persist Security Info=False;User ID=adminuser;Password=Admin1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir "Data" -DataAnnotations |

CREATE USER applicationUser with PASSWORD = 'App1234567'

GRANT select, insert, update, delete to applicationUser




Step 1.
1. Create a SQL database project
2. Add the required tables and post-deployment scripts to this
3. Publish this project to your Azure SQL instance

Step 2.
1. Create a new .NET core MVC project 
2. Install the nuget packages
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="5.0.12">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.12" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.12">
3. Scaffold the DB context - run the below command in the visual studio package manager console:
Scaffold-DbContext "<your conn string>" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir "Data" -DataAnnotations
4. Create new controllers using Entity Framework with models and views


