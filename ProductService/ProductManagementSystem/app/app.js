angular.module('pmsApp', ['ngRoute'])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);

        $routeProvider.when('/home', {
            templateUrl:'app/home/views/home.view.html'
        })
        .when('/products', {
            templateUrl: '/app/products/views/products.view.html',
            controller: 'productsController',
            controllerAs:'vm'
        })
        .otherwise({
            redirectTo:'/home'
        });
    }]);