TimeServiceWixDemo
==================

Demonstrates a WiX setup project that installs and starts a Windows Service. 

The service consists of a simple self-hosted WebApi controller with a single Index action that returns the current Date and time as a string.

The installer automatically installs and starts the service during installation, and will stop and remove the service during uninstallation. 

It also demonstrates how to use a custom action to enable a WCF namespace reservation on a TCP port during the installation. This solution is thanks to Geoff Webber: 
    http://geoffwebbercross.blogspot.com/2011/08/wix-3-netsh-customaction.html

