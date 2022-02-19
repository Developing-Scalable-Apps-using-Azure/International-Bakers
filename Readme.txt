dotnet ef dbcontext scaffold "Server=tcp:ibdbserver.database.windows.net,1433;Initial Catalog=ibdb;Persist Security Info=False;User ID=adminuser;Password=Admin1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
Scaffold-DbContext "Server=tcp:ibdbserver.database.windows.net,1433;Initial Catalog=ibdb;Persist Security Info=False;User ID=adminuser;Password=Admin1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
Scaffold-DbContext "Server=tcp:ibdbserver.database.windows.net,1433;Initial Catalog=ibdb;Persist Security Info=False;User ID=adminuser;Password=Admin1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir "Data" -DataAnnotations |

CREATE USER applicationUser with PASSWORD = 'App1234567'

GRANT select, insert, update, delete to applicationUser