var client = null;

function getClient() {
    var MobileServiceClient = WindowsAzure.MobileServiceClient,
        appUrl = 'https://kudogen.azure-mobile.net/',
        appKey = 'osuEzuBglAbnLbdYKzEAyuMHrndLvC71';
    client = client || new MobileServiceClient(appUrl, appKey);
    $('#summary').html('');
    return client;
}

function refreshAuthDisplay(loggedInUser) {
    var client = getClient,
        user = loggedInUser || client.currentUser,
        isLoggedIn = !!user;
    $("#logged-in").toggle(isLoggedIn);
    $("#logged-out").toggle(!isLoggedIn);

    if (isLoggedIn) {
        // This just means they are authenticated with their Microsoft Account
        // Try to read their details from the TeamMembers table
        client.getTable('TeamMembers').where({
            teamMemberID: user.userId
        }).read().done(function (userDetails) {
            var details = userDetails[0];
            if (details) {
                if (details.approved) {
                    // Good to go
                    $("#login-name").text(details.displayName);
                    refreshTodoItems();
                } else {
                    // Found, but not approved
                    $('#summary').html('Unable to authenticate you. Please check with the admins.');
                }
            } else {
                // User not found, so insert them for approval
                teamMembersTable.insert({ teamMemberId: user.userId });
                $('#summary').html('Sweet! You have been registered and will be notified when an admin approves you. Cheers!');
            }
        }, function (err) {
            alert(err);
        });
    }
}

function logIn() {
    var client = getClient();
    client.login("microsoftaccount").then(refreshAuthDisplay, function (error) {
        alert(error);
    });
}

function logOut() {
    var client = getClient();
    client.logout();
    refreshAuthDisplay();
    $('#summary').html('You must login to access data.');
}

// On page init, fetch the data and set up event handlers
$(function () {
    refreshAuthDisplay();
    $('#summary').html('<strong>You must login to access data.</strong>');
    $("#logged-out button").click(logIn);
    $("#logged-in button").click(logOut);
});
