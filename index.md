# Welcome to the course assessment for building scalable applications on Azure

This course is composed up of the below sections:

### Section 1 [15 Points]
Multiple choice Questions

### Section 2 [30 Points]
Lab Exercise

### Time Given
3 Hours

## Section 1 - MCQs

```markdown
Question 1. Which one of the following is an orchestration software which can be used for scaling containers?

A. Azure Batch.
B. Azure Kubernetes.
C. Azure Data Factory.
D. Azure key vault.


Question 2. What is the basic operational unit of Kubernetes?

A. Pod
B. Container
C. Nodes
D. Task


Question 3. Which one of the following can be done for a container based application using Azure Kubernetes?

A. Making container scalability easy.
B. Make workloads portable.
C. Build more extensible apps.
D. All of the above.


Question 4. You deploy a web application to an Azure App Service. The application uses a storage 
account that contains a large number of storage objects. 
You need to grant clients access to application data for a specified interval of time while 
minimizing effort. 
What should you create? 

A. a stored access policy 
B. a service shared access signature 
C. an account shared access signature 
D. a network security group 


Question 5. Which one of the following is incorrect regarding Azure Kubernetes?

A. Azure Kubernetes does not mandatorily need resources to be created in cloud.
B. Azure Kubernetes manages and makes deployment of container based applications easy.
C. Azure Kubernetes helps in automatic scheduling of container based application.
D. None of these.


Question 6. Choose the correct option.

A. Azure Kubernetes is an open source platform.
B. etcd is used to maintain the state of Kubernetes cluster and configuration.
C. Both A and B.
D. Neither A nor B.


Question 7. You manage an Azure Web Site that is running in Shared mode. 
You discover that the website is experiencing increased average response time during 
periods of heavy user activity. 
You need to update the website configuration to address the performance issues as they 
occur. 
What should you do? 
 
A. Set the website to Standard mode and configure automatic scaling based on CPU utilization. 
B. Configure automatic seating during specific dates. 
C. Modify the website instance size. 
D. Configure automatic scaling based on memory utilization. 
E. Set the website to Basic mode and configure automatic scaling based on CPU utilization. 


Question 8. Which one of the following is correct regarding clusters of Azure Kubernetes?

A. Cluster name need not be unique within the selected resource group.
B. Azure CLI can be used to create clusters.
C. Both A and B.
D. Neither A nor B.


Question 9. Choose the correct option.

A. It can integrate with Azure Active Directory.
B. Role based access control is possible in Azure Kubernetes.
C. Both A and B.
D. None of these.


Question 10. Which one of the following permission must be given to the service principal to establish authentication between AKS and ACR?

A. ACR.Write
B. ACR.Push
C. ACR.Pull
D. B and C

Question 11. How do I add a message to a commit?
A. $ git message "Fix error in xxxx"
B. $ git add "Fix error in xxxx"
C. $ git commit "Fix error in xxxx"
D  $ git commit -m "Fix error in xxxx"


Question 12. You manage an application running on Azure Web Sites Standard tier. The application 
uses a substantial amount of large image files and is used by people around the world. 
Users from Europe report that the load time of the site is slow. 
You need to implement a solution by using Azure services. 
What should you do? 
 
A. Configure Azure blob storage with a custom domain. 
B. Configure Azure CDN to cache all responses from the application web endpoint. 
C. Configure Azure Web Site auto-scaling to increase instances at high load. 
D. Configure Azure CDN to cache site images and content stored in Azure blob storage. 


Question 13. Your company network has two physical locations configured in a geo-clustered 
environment. You create a Blob storage account in Azure that contains all the data 
associated with your company. 
You need to ensure that the data remains available in the event of a site outage. 
Which storage option should you enable? 

A. Locally redundant storage 
B. Geo-redundant storage 
C. Zone-redundant storage 
D. Read-only geo-redundant storage 


Question 14. You administer an Azure Web Site named contoso. The development team has 
implemented changes to the website that need to be validated. 
You need to validate and deploy the changes with minimum downtime to users. 
What should you do first?

A. Create a new Linked Resource. 
B. Configure Remote Debugging on contoso. 
C. Create a new website named contosoStaging. 
D. Create a deployment slot named contosoStaging. 
E. Back up the contoso website to a deployment slot. 


Question 15. How can you expose K8S deployments externally?
A. PVCs
B. Services
C. Ingress
D. B and C

```

## Section 2 - Lab Exercise

```markdown

**Lab Title:** International Bakers - A scalable and performant web application using Azure PaaS services.


**Description:**
This lab covers the below dimensions of AKS and GitHub:
1. App Service Operations
2. Integration with Azure SQL
4. Integration with Azure CDN
5. Integration with Azure Storage
6. Integration with Azure AD

The proof of executions for this lab are requested to be uploaded to the below location:
https://1drv.ms/u/s!AjKtnZen93C0nRWh0myuo4CTCqyH?e=haO08c

**Business Requirements:**

- Only authenticated users must be able to access this web application
- The application users must provide the capability to perform cookie operations - CRUD
- Optionally, The application users must be able to perform store and order operations - CRUD
- Business users must validate the new versions of the web application before you publish them to the production site. You must be able to revert to the previous versioneasily when issues arise


**Technical Requirements:**
- You must develop this application using ASP .NET, where a list of Cookies, Stores and Orders is visible to authenticated users with all the CRUD operations. 
- Use Azure SQL Database as a Service to create a database with this refrence project: https://github.com/Developing-Scalable-Apps-using-Azure/International-Bakers/tree/master/InternationalCookies.DataBase/
- Improve the application performance by using a suitable caching mechanism. 
- Ensure auto scaling based on CPU utilization.
- All the cookie images have to be uploaded to Azure Storage. 
- Add a status column to the dbo.Stores
- Create an automated workflow for onboardong a new store to your application where the status changes from 'Under Review' to 'Onboarded' based on an email approval.
- Implement a DNS based caching mechanism for loading these images faster, thereby improving application performance. 
- Ensure that application level Logging and Web Server Level Logging is in place for the deployed application. 
- Enable Application level monitoring. 
- Create an excel sheet to calculate estimates of the complete production environment. Also give details related to sizing, pricing and assumptions, if any.  

```
