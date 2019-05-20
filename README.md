Console application developed in VS2017, targetting against .Net 4.6.1.

Solution is divided into two projects - main and test project.

High level design:

1. Card, card reading and pin validation are considered as client side operations (where the card reader machine/console is the client and card along with the pin are the inputs).

2. Server side consists of services such as query account balance, topup and withdraw.

3. Main program acts as the interface with users accepting inputs along with basic validations.

