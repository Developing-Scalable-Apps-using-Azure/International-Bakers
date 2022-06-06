Step 1.
1. Provision a Basic tier Azure Database instance on the Azure Portal
2. Create a SQL database project
3. Add the required tables and post-deployment scripts to this
4. Publish this project to your Azure SQL instance
5. Create application users and assign permissions
```
CREATE USER applicationUser with PASSWORD = 'App1234567'
GRANT select, insert, update, delete to applicationUser
```

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
```
Scaffold-DbContext "<your conn string>" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir "Data" -DataAnnotations
```
4. Create new controllers using Entity Framework with models and views
5. Dependency injectr the connection string using startup.json
```
    services.AddDbContext<ibdb01Context>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("ibdb01")));
```

Step 3.
1. Add support for Azure Redis
	  <PackageReference Include="Microsoft.Extensions.Caching.Redis" Version="2.2.0" />
	  <PackageReference Include="StackExchange.Redis" Version="2.2.88" />
3. Add the cache connection string to appsettings.json
4. Dependency inject the cache connection using startup.cs
```
            services.AddDistributedRedisCache(option => {
                option.Configuration = Configuration.GetConnectionString("ibcache01");
                option.InstanceName = "master";
```
5. Update the CustomersController to fetch the list from redis
```
 public async Task<IActionResult> Index()
        {
            List<Cookie> cookies;
            var cachedCookies = _cache.GetString("cookieList");

            if (!string.IsNullOrEmpty(cachedCookies))
            {
                cookies = JsonConvert.DeserializeObject<List<Cookie>>(cachedCookies);
            }
            else
            {
                cookies = _context.Cookies.ToList();
                _cache.SetString("cookieList", JsonConvert.SerializeObject(cookies));
            }

            return View(cookies);
        }
```


Step 4.
Create an Azure AD app registration
value
S3h8Q~d7p835hKkVQMMBh2sZ1LIkhGUm1Jpd6cst
ID
fc0ec619-e702-4c8a-9c7f-78ba3685a46f
1. In appsettings.json:
     "AzureAd": {
        "Instance": "https://login.microsoftonline.com/",
        "Domain": "siddharthdwngmail.onmicrosoft.com",
        "TenantId": "0e97f85a-b424-40f3-8fcc-bdde6023332e",
        "ClientId": "8fa7b6f3-3378-43b0-ad32-2dcffb3131e2",
        "CallbackPath": "/signin-oidc"
      }

2. Add support for Azure AD
```
 <PackageReference Include="Microsoft.Identity.Web" Version="1.1.0" />
 <PackageReference Include="Microsoft.Identity.Web.UI" Version="1.1.0" />
 <PackageReference Include="Microsoft.IdentityModel.Clients.ActiveDirectory" Version="5.2.9" />
 ```
3. Update startup.cs
In the ConfigureServices method:
```
services.AddControllersWithViews(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddRazorPages()
                 .AddMicrosoftIdentityUI();
                 
services.Configure<CookiePolicyOptions>(options =>
            {
                options.Secure = CookieSecurePolicy.Always;
            });
            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));
```         
In the configure method:
 
```
app.UseCookiePolicy();
app.UseAuthentication();
```                
	

	

Sample Commands - Do not run directly
```
dotnet ef dbcontext scaffold "Server=tcp:ibdbserver.database.windows.net,1433;Initial Catalog=ibdb;Persist Security Info=False;User ID=adminuser;Password=Admin1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
Scaffold-DbContext "Server=tcp:ibdbserver.database.windows.net,1433;Initial Catalog=ibdb;Persist Security Info=False;User ID=adminuser;Password=Admin1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
Scaffold-DbContext "Server=tcp:ibdbserver.database.windows.net,1433;Initial Catalog=ibdb;Persist Security Info=False;User ID=adminuser;Password=Admin1234567;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -ContextDir "Data" -DataAnnotations |
```
        
