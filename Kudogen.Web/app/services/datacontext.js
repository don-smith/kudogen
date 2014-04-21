(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', 'entityManagerFactory', datacontext]);

    function datacontext(common, emFactory) {
        var $q = common.$q;
        var EntityQuery = breeze.EntityQuery;
        var manager = emFactory.newManager();
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(serviceId);
        var logError = getLogFn(serviceId, 'error');
        var logSuccess = getLogFn(serviceId, 'success');

        var service = {
            getTeamMembers: getTeamMembers
        };

        return service;

        function getTeamMembers() {
            var teamMembers;
            var query = new EntityQuery('TeamMembers');

            return manager.executeQuery(query)
                .then(querySucceeded, queryFailed);

            function querySucceeded(data) {
                teamMembers = data.results;
                log('Retrieved [TeamMembers] from remote data source', teamMembers.length, true);
                return teamMembers;
            }
        }

        function queryFailed(error) {
            var msg = config.appErrorPrefix + 'Error retreiving data.' + error.message;
            logError(msg, error);
            throw error;
        }
    }
})();