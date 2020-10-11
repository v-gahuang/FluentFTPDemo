## Agenda 30 minutes

### Enhancement Tech Change
#### Backend
##### Ftp Files Fetch Tuning
##### Notification Integration
###### Email Notification
System.Net.Mail -> SmtpClient
Using Engine.Razor Generate Email Html Body

###### Rocket Check Notification
WebClient Client Post Http Rocketchat Notification

##### Notification Scheduler
###### Quartz.Net
Quartz.NET is a handy library that allows you to schedule recurring tasks via implementing IJob interface.
At its simplest, Quartz consists of 3 primary components - a job, a trigger and a scheduler. A job is the task to be performed. The trigger dictates how and when the job is executed. Together, the job and the trigger are registered with the scheduler, which takes care of ensuring that the job is performed on the schedule dictated by the trigger configuration.

###### Cron Trigger
CronTriggers are often more useful than SimpleTrigger, if you need a job-firing schedule that recurs based on calendar-like notions, rather than on the exactly specified intervals of SimpleTrigger.

Cron-Expressions are strings that are actually made up of seven sub-expressions, that describe individual details of the schedule. These sub-expression are separated with white-space, and represent:
###### All Service Notification
###### All Ftp Files Notification
###### Single Service Notification 
##### Swagger
#### Frontend
##### Service Group
##### 
### Demo
#### Service Group
#### Add or Remove Service
#### Single Service Notification
### Further Enhancement
#### Add Database
#### Seperate UI
#### Data Quality Check
### Reference
#### Conference Page
#### Healthcher Repository
#### Quartz.net Cron Trigger
### Q&A