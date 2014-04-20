(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', datacontext]);

    function datacontext(common) {
        var $q = common.$q;

        var service = {
            getTeamMembers: getTeamMembers
        };

        return service;

        function getTeamMembers() {
            var teamMembers = [
                { name: 'John Papa', email: 'Papa', isAdmin: false, isApproved: true },
                { name: 'Ward Bell', email: 'Bell', isAdmin: false, isApproved: true },
                { name: 'Colleen Jones', email: 'Jones', isAdmin: false, isApproved: true },
                { name: 'Madelyn Green', email: 'Green', isAdmin: false, isApproved: true },
                { name: 'Ella Jobs', email: 'Jobs', isAdmin: false, isApproved: true },
                { name: 'Landon Gates', email: 'Gates', isAdmin: false, isApproved: true },
                { name: 'Haley Guthrie', email: 'Guthrie', isAdmin: false, isApproved: true }
            ];
            return $q.when(teamMembers);
        }
    }
})();