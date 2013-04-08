SalesForce to NServiceBus
===

This example project shows how you can do SalesForce interop with the .net platform combined with using NServiceBus. I tried to
keep it as simple as possible with the remark that most code really is not of production quality. For example, it misses:

* exception handling,
* result checking,
* input validation
* authentication
* authorisation

It is missing these things as I want to demo the following:

* How you can send an update to salesforce when an entity in your environment has been updated by implementing an event handler.
* How you can receive a salesforce outbound message and pass it to NServiceBus to do the actual processing.

Projects
---

I tried to divide to code in to the following parts:

* Messages, contain the commands and events for the demo service
* CRMHost, NServiceBus host that processes commands and publishes events (publisher)
* SalesForceAdapterHost, NServiceBus host that subscribes to an CRMHost event, pushes a change to salesforce, receives a update
notification from salesforce and sends a command the CRMHost.

WCF Self hosting
---
The SalesForceAdapterHost uses WCF self hosting and starts this during the NServiceBus initialization. I used this so that you
will not have to register a website in IIS and that one process does both the SalesForce communication. This is probably not an
option when you want to apply techniques as http load-balancing to enable load-balancing or fail-over as you probably want to
split it in multiple processes but this makes the demo hassle free.

Dependancy Injection
---

Although I tried to keep it simple I still choose to use dependancy injection as this what a lot of people use. In this example I
use Autofac as I didn't use it before and thought that would be nice for a change. All stuff is pretty straight forward except the
WCF initialization that configures dependancy injection but I copied that from the Autofac wiki.


