angular.module('pmsApp', ['ngRoute', 'AdalAngular'])
    .config(['$routeProvider', '$locationProvider','adalAuthenticationServiceProvider','$httpProvider', function ($routeProvider, $locationProvider,adalAuthenticationServiceProvider,$httpProvider) {
        //hashPrefix(!) is needed for ADAL angular to work properly
        $locationProvider.html5Mode(true).hashPrefix('!');

        //client id is the app id of the client/native app
        //apis are the list of endpoints for which $httpProvider should be intercepted to add the token
        adalAuthenticationServiceProvider.init({
            instance:'https://login.microsoftonline.com/',
            tenant:'shaijurnd.onmicrosoft.com',
            clientId: 'b5f373c9-78cf-49f1-ab32-ad4fbd186198',
            endpoints: {
                'https://localhost:44326/':'https://shaijurnd.onmicrosoft.com/ProductService'
            }
        },$httpProvider);

        $routeProvider.when('/home', {
            templateUrl:'app/home/views/home.view.html'
        })
        .when('/products', {
            templateUrl: '/app/products/views/products.view.html',
            controller: 'productsController',
            controllerAs:'vm',
            requireADLogin:true
        })
        .otherwise({
            redirectTo:'/products'
        });
    }]);