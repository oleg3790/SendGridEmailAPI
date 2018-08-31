# Overview
This solution provides a RESTful API server that can consume an email message context and send the email using the .NET SendGrid library.

### Prerequisites
To use this solution in its current state; before launching the project, add a json config file with a name of **sendgridconfig.json** that contains a key name of **APIKey** (which should contain the value of the SendGrid API key). The project is configured to automatically look for this configuration.
