(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'datacontext', dashboard]);

    function dashboard(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Hot Towel Angular',
            description: 'Hot Towel Angular is a SPA template for Angular developers.'
        };
        vm.teamMembers = [];
        vm.title = 'Dashboard';

        activate();

        function activate() {
            common.activateController([getTeamMembers()], controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }

        function getTeamMembers() {
            return datacontext.getTeamMembers().then(function (data) {
                return vm.getTeamMembers = data;
            });
        }
    }
})();