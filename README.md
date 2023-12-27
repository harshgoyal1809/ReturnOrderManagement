## Return Order Management Portal

### Project Manager - Harsh Goyal

---
## **OBJECTIVE**
A leading Supply chain Management Organization wants to automate the return orders, by classifying them to repair or replacement.
Repair is for all main or integral part of their product. Replacement is for accessories. 

## **SCOPE & SOLUTION**
As part of the build, the web application has been divided into 5 parts that includes four 'Web Api microservices' and one 'Return Order Portal'. The individual components (web apis) provide the required rest-end points and all end-points have been configured and called internally using 'HttpClient' in other microservices and the portal as required.

## **MICRO SERVICES FUNCTIONALITY**

**_Component Processing Microservice:_**
1. Determine if the request is for Repair or Replacement 

2. Determine the repair or replacement cost along with the consideration if it’s a priority request or not. Determine the date of process completion 

3. Invoke Packaging and Delivery service to determine the cost and date of delivery 

4. Return the Processing response detail object


**_Packaging and Delivery Microservice:_**
1. Determine the packaging and delivery charge for the item based on a pre-defined logic 

2. Provide the expected date of delivery.

**_Payment Microservice:_**
1. Gets the processing charge and the Credit card detail as input. Deducts the amount and provides the result message if the deduction succeeded or not

**_Authorization Microservice:_**
1. This microservice is used with anonymous access to Generate JWT


---

## GITHUB LINK: ##
https://github.com/harshgoyal1809/ReturnOrderManagement
---



