angular.module('pmsApp')
    .controller('productsController', ['$http', function ($http) {
        var self = this;
        $http.get('https://localhost:44326/api/products').then(function (res) {
            self.products = res.data;
        });
    }]);