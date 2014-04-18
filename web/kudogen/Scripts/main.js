function getClient() {
    var MobileServiceClient = WindowsAzure.MobileServiceClient,
        appUrl = 'https://kudogen.azure-mobile.net/',
        appKey = 'osuEzuBglAbnLbdYKzEAyuMHrndLvC71';
    return new MobileServiceClient(appUrl, appKey);
}
function refreshAuthDisplay() {
    var client = getClient(),
        isLoggedIn = client.currentUser !== null;
    $("#logged-in").toggle(isLoggedIn);
    $("#logged-out").toggle(!isLoggedIn);

    if (isLoggedIn) {
        $("#login-name").text(client.currentUser.userId);
        refreshTodoItems();
    }
}

function logIn() {
    var client = getClient();
    client.login("windowsaccount").then(refreshAuthDisplay, function (error) {
        alert(error);
    });
}

function logOut() {
    var client = getClient();
    client.logout();
    refreshAuthDisplay();
    $('#summary').html('<strong>You must login to access data.</strong>');
}

// On page init, fetch the data and set up event handlers
$(function () {
    refreshAuthDisplay();
    $('#summary').html('<strong>You must login to access data.</strong>');
    $("#logged-out button").click(logIn);
    $("#logged-in button").click(logOut);
});
