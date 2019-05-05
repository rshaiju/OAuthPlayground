angular.module('pmsApp').controller('usersController', ['$http', function ($http) {
    var self = this;
    $http.get('https://localhost:44317/api/users').then(function (res) {
        self.users = res.data;
    });
}]);