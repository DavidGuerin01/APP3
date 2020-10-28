// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
displayComments();
function displayComments() {

    $.get("api/values", function (data) {
        $("#commentSection").html(data);
        
    });
}

function addComment() {
    console.log("test");
    console.log(ResolveUrl("~/api/values/manette/xbox"));
    $.ajax({
        url: "api/values/manette/xbox",
        type: "POST",
        data: {
            commentaire: $("#NewComment").val()
        },
        success: function (status) {
            if (status != "success") {
                alert(status);
            }

            //$("#NewComment").hide();
            //$("#NewCommentsBtn").val("Nouveau commentaire");
            //displayComments();
        },
        error: function (info) {
            console.log(info);
        }
    }
    );
}