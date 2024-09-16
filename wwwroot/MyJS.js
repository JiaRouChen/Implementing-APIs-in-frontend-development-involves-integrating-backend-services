class UseAPI {

    ListData(url,callback) {
        $.ajax({
            type: "Get",
            url: url,
            success: function (data) {
                callback(data);
            },
            error: function (resp) {
            }
        });
    }

    GetData(url, callback) {
        $.ajax({
            type: "Get",
            url: url,
            success: function (data) {
                callback(data);
            },
            error: function (resp) {
            }
        });
    }

    CreateData(url, jsonData, callback) {
        $.ajax({
            type: "Post",
            url: url,
            contentType: "application/json",
            data: jsonData,
            success: function (data) {
                callback(data);
            },
            error: function (resp) {
            }
        });
    }

    UpdateData(url, jsonData, callback) {
        $.ajax({
            type: "Put",
            url: url,
            contentType: "application/json",
            data: jsonData,
            success: function (data) {
                callback(data);
            },
            error: function (resp) {
            }
        });
    }

    DeleteData(url, callback) {
        $.ajax({
            type: "Delete",
            url: url,
            success: function (data) {
                callback(data);
            },
            error: function (resp) {
            }
        });
    }
}
