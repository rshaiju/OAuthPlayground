angular.module('pmsApp').controller('usersController', ['$http', function ($http) {
    var self = this;
    $http.get('https://localhost:44364/api/users').then(function (res) {
        self.users = res.data;
    });
}]);