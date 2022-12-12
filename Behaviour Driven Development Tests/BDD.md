<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
    <h1>Behaviour Driven/ Functional testing</h1>
    <table>
        <tr>
            <th>S.No.</th>
            <th>Application</th>
            <th>Action</th>
            <th>Expectation</th>
            <th>Status</th>
            <th>Screenshot</th>
        </tr>
        <tr>
            <td>1.</td>
            <td>Windows Form</td>
            <td>Windows form application is opened for the first time</td>
            <td>If there is no database, then a new database is created and the output field of the windows form is empty</td>
            <td><img src="images/passed.png" alt="Passed" width="15%" title="Passed"></td>
            <td><a id="one" href="images/1.png" target="_blank">Figure 1</a></td>
        </tr>
        <tr>
            <td>2.</td>
            <td>Windows Form</td>
            <td>User clicks on submit button without typing anything in the input field</td>
            <td>The output field of Windows form remains empty if no data is submitted from Web application and an alert is generated</td>
            <td><img src="images/passed.png" alt="Passed" width="15%" title="Passed"></td>
            <td><a id="two" href="images/2.png" target="_blank">Figure 2</a></td>
        </tr>
        <tr>
            <td>3.</td>
            <td>Windows Form</td>
            <td>User types "Hello" in the input field and clicks on submit button</td>
            <td>The output field of the windows form remains empty if no data is submitted from Web application</td>
            <td><img src="images/passed.png" alt="Passed" width="15%" title="Passed"></td>
            <td><a id="three" href="images/3.png" target="_blank">Figure 3</a></td>
        </tr>
        <tr>
            <td>4.</td>
            <td>Windows Form</td>
            <td>Multiple instances of Windows Form are opened and User types "Testing" in the input field of one of the forms and clicks on submit button</td>
            <td>The output field of both the forms remains empty if no data is submitted from Web application</td>
            <td><img src="images/passed.png" alt="Passed" width="15%" title="Passed"></td>
            <td><a id="four" href="images/4.png" target="_blank">Figure 4</a></td>
        </tr>
        <tr>
            <td>5.</td>
            <td>Windows Form</td>
            <td>Nothing has been submitted in windows form application</td>
            <td>The output field of the windows form contains "Hi" if the Web application had submited "Hi" message</td>
            <td><img src="images/passed.png" alt="Passed" width="15%" title="Passed"></td>
            <td><a id="five" href="images/5.png" target="_blank">Figure 5</a></td>
        </tr>
        <tr>
            <td>6.</td>
            <td>Windows Form</td>
            <td>Multiple instances of Windows Form is opened</td>
            <td>The output field of both the windows forms contains "Hi" if the Web application had submited "Hi" message</td>
            <td><img src="images/passed.png" alt="Passed" width="15%" title="Passed"></td>
            <td><a id="six" href="images/6.png" target="_blank">Figure 6</a></td>
        </tr>
        <tr>
            <td>7.</td>
            <td>Web app</td>
            <td>Web app is opened for the first time</td>
            <td>If there is no database, then a new database is created and the output field of the web app is empty</td>
            <td><img src="images/passed.png" alt="Passed" width="15%" title="Passed"></td>
            <td><a id="seven" href="images/7.png" target="_blank">Figure 7</a></td>
        </tr>
        <tr>
            <td>8.</td>
            <td>Web app</td>
            <td>User clicks on submit button without typing anything in the input field of web app</td>
            <td>The output field of Web app remains empty if no data is submitted from Windows form and an alert is generated</td>
            <td><img src="images/passed.png" alt="Passed" width="15%" title="Passed"></td>
            <td><a id="eight" href="images/8.png" target="_blank">Figure 8</a></td>
        </tr>
        <tr>
            <td>9.</td>
            <td>Web app</td>
            <td>Nothing is submitted in the Web app</td>
            <td>The output field of the Web app contains "Message: Hello sent from Sender: WindowsFormApplication1" if the Windows Form 1 had submited "Hello" message</td>
            <td><img src="images/passed.png" alt="Passed" width="15%" title="Passed"></td>
            <td><a id="nine" href="images/9.png" target="_blank">Figure 9</a></td>
        </tr>
        <tr>
            <td>10.</td>
            <td>Web app</td>
            <td>Nothing is submitted in the Web app</td>
            <td>The output field of the Web app contains "Message: Hello sent from Sender: WindowsFormApplication1" and "Message: Good day sent from Sender: WindowsFormApplication2" if the Windows Form 1 had submited "Hello" message and Windows From 2 has submitted "Good day"</td>
            <td><img src="images/passed.png" alt="Passed" width="15%" title="Passed"></td>
            <td><a id="ten" href="images/10.png" target="_blank">Figure 10</a></td>
        </tr>
        <tr>
            <td>11.</td>
            <td>Web app</td>
            <td>User types "Hi" in the input field of the Web app and clicks submit</td>
            <td>The output field of the Web app remains empty if no data is submitted from Windows Form</td>
            <td><img src="images/passed.png" alt="Passed" width="15%" title="Passed"></td>
            <td><a id="eleven" href="images/11.png" target="_blank">Figure 11</a></td>
        </tr>
    </table>
</body>
</html>
