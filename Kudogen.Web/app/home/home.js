(function () {
    'use strict';
    var controllerId = 'home';
    angular.module('app').controller(controllerId, ['common', 'datacontext', home]);

    function home(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.teamMembers = [];
        vm.title = 'Home';

        activate();

        function activate() {
            common.activateController([getTeamMembers()], controllerId)
                .then(function () { log('Activated Home View'); });
        }

        function getTeamMembers() {
            return datacontext.getTeamMembers().then(function (data) {
                return vm.teamMembers = data;
            });
        }
    }
})();