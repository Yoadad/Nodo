var Nodo = Nodo || {};
(function ($,Nodo) {
    var serviceRoot = "/api";
    var datasource = new kendo.data.HierarchicalDataSource({
        transport: {
            read: {
                url: function (options) {
                    console.log(options);
                    return kendo.format("/Api/Nodes/{0}", options.Id);
                },
                dataType: "json"
            }
        },
        schema: {
            model: {
                Id: "Id",
                Name: 'Name',
                hasChildren: function () { return true;}
            }
        }
    });

    $("#tree").kendoTreeView({
        dataSource: datasource,
        dataTextField: "Name"
    });
}(jQuery, Nodo));
