## Tech Change
### Notification
#### Email Notification
System.Net.Mail -> SmtpClient
##### EmailClient Razor Template
Using Engine.Razor Generate Email Html Body

#### Rocket Chat Notification
All Service Notification occures twice working days
All FtpFiles Notification occurs once working days
Single Service Notification will configuration 10 times

Calulate the fabiconic sequecnes
And caculate the service status every minute then records the times, if match the trigger then will send the notification

WebClient Client Post Http Rocketchat Notification

#### Quartz.NET
Quartz.NET is a handy library that allows you to schedule recurring tasks via implementing IJob interface. Yet the limitation of it is that, by default, it supports only parameterless constructor which complicates injecting external service inside of it, i.e., for implementing repository pattern. In this article, we'll take a look at how we can tackle this problem using standard .NET Core DI container.

A much more robust solution can be found in the shape of Quartz.NET - an open source scheduling library which is available via nuget. This article looks at a basic implementation that will get you up and running with a scheduled email job. I have chosen to use a Web Forms application to illustrate the use of Quartz.NET in an ASP.NET setting, but the steps are easily translated to MVC or Web Pages.

At its simplest, Quartz consists of 3 primary components - a job, a trigger and a scheduler. A job is the task to be performed. The trigger dictates how and when the job is executed. Together, the job and the trigger are registered with the scheduler, which takes care of ensuring that the job is performed on the schedule dictated by the trigger configuration.
##### Schedule Job
Have Initial Schdule Job when start up, then could change the schedule job dynamically using WebAPI

##### Cron Trigger
Cron-Expressions are used to configure instances of CronTrigger. Cron-Expressions are strings that are actually made up of seven sub-expressions, that describe individual details of the schedule. These sub-expression are separated with white-space, and represent:

CronTriggers are often more useful than SimpleTrigger, if you need a job-firing schedule that recurs based on calendar-like notions, rather than on the exactly specified intervals of SimpleTrigger.

###### Multiple Triggers
Support One Job with Multiple Triggers, and use semicolon to join the jobs


##### Ftp File Check
###### TPL
Using the TPL framework
No Dependency and Race Condition
The Concurrency Collection to Collect the response
https://dotnettutorials.net/lesson/parallel-foreach-method-csharp/

 Parallel ForEach
 Degree of Parallelism

 Using the Degree of Parallelism we can specify the maximum number of threads to be used to execute the program. The syntax to use the Degree of Parallelism is given below.

 The MaxDegreeOfParallelism property affects the number of concurrent operations run by Parallel method calls that are passed this ParallelOptions instance. A positive property value limits the number of concurrent operations to the set value. If it is -1, there is no limit on the number of concurrently running operations.

By default, For and ForEach will utilize however many threads the underlying scheduler provides, so changing MaxDegreeOfParallelism from the default only limits how many concurrent tasks will be used.

###### Improve from 7 mintutes to 1 minutes


### UI Improvement
#### Service Ehancement
#### Service Group


