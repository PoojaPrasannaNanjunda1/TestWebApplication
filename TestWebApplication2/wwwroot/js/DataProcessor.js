/***********************************
** DataProcessor.js
** Author: Pooja Prasanna Nanjunda
** Email: poojananjunda1996@gmail.com
** Date: 04-12-2022
***********************************/

setInterval(function () {

    // Create XMLHttpRequest object
    const xmlRequest = new XMLHttpRequest()

    // Open a get request with the remote server URL
    xmlRequest.open("GET", "http://localhost:80/Data")

    // Send the Http request
    xmlRequest.send()

    // Event triggered when the response is completed
    xmlRequest.onload = function () {
        if (xmlRequest.status === 200) {

            // Parse JSON data
            data = JSON.parse(xmlRequest.responseText)

            let outputString = ""
            data.forEach((element) => outputString = outputString.concat('\n\n', element.dataText));

            // Display the response data.
            let outputData = document.getElementById("OutputData");
            outputData.value = outputString.slice(2)
        }
        else if (xmlRequest.status === 404)
        {
            console.log("No records found")
        }
        else if (xmlRequest.status === 204)
        {
            console.log("No content");
        }
        else if (xmlRequest.status === 400)
        {
            console.log("Bad request");
        }
    }
}, 1000);



// POST method implementation:
function PostDataToTestTable2() {

    // Get user input
    const inputString = document.getElementById("InputData")

    // Send the Http request
    fetch('http://localhost:80/Data',
        {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                DataText: inputString.value
            }),
    })
    .then((response) => console.log(response.status))
}





