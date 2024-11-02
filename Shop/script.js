// Tự động chuyển slide
let slideIndex = 0;
// function addToCart(productName, productPrice) {
//     const cart = JSON.parse(localStorage.getItem('cart')) || [];
//     console.log("Giỏ hàng hiện tại:", cart);

//     const productIndex = cart.findIndex(item => item.name === productName);
//     if (productIndex > 0) {
//         cart[productIndex].quantity += 1;
//     } else {
//         cart.push({ name: productName, price: productPrice, quantity: 1 });
//     }

//     localStorage.setItem('cart', JSON.stringify(cart));
//     alert(`${productName} đã được thêm vào giỏ hàng!`);
//     updateCartDisplay();
// }

// // Hiển thị giỏ hàng
// function updateCartDisplay() {
//     const cart = JSON.parse(localStorage.getItem('cart')) || [];
//     console.log("Cập nhật hiển thị giỏ hàng:", cart);

//     const cartContainer = document.getElementById("cart-display");
//     cartContainer.innerHTML = ""; // Xóa nội dung cũ

//     cart.forEach(item => {
//         const cartItem = document.createElement("div");
//         cartItem.classList.add("cart-item");
//         cartItem.textContent = `${item.name} - ${item.quantity} x ${item.price} VND`;
//         cartContainer.appendChild(cartItem);
//     });

//     const totalQuantity = cart.reduce((total, item) => total + item.quantity, 0);
//     document.getElementById("cart-count").textContent = `(${totalQuantity})`;
// }

// // Tìm kiếm sản phẩm và đánh dấu
// document.getElementById("search-btn").addEventListener("click", function () {
//     const searchQuery = document.getElementById("search").value.toLowerCase();
//     const productItems = document.querySelectorAll(".product-item");
//     let found = false;
//     console.log("Từ khóa tìm kiếm:", searchQuery);

//     productItems.forEach(item => {
//         const title = item.querySelector("h3").textContent.toLowerCase();
//         console.log("Tên sản phẩm:", title);

//         if (title.includes(searchQuery)) {
//             found = true;
//             item.style.display = "block";
//             item.classList.add("highlight");
//             if (!found) {
//                 item.scrollIntoView({ behavior: "smooth" });
//                 found = true;
//             }
//         } else {
//             item.style.display = "none";
//             item.classList.remove("highlight");
//         }
//     });

//     if (!found) {
//         alert("Không tìm thấy sản phẩm nào phù hợp với tìm kiếm của bạn.");
//         productItems.forEach(item => item.style.display = "block");
//     }
// });

// // Xóa đánh dấu khi người dùng chỉnh sửa từ khóa
// document.getElementById("search").addEventListener("input", function () {
//     document.querySelectorAll(".product-item").forEach(item => item.classList.remove("highlight"));
// });
function addToCart(id) {
    const cart = JSON.parse(localStorage.getItem('cart')) || [];
    const listPro = JSON.parse(localStorage.getItem('listProduct')) || [];
    console.log("Giỏ hàng hiện tại:", cart);

    const productIndex = cart.findIndex(item => item.id === id);
    if (productIndex > 0) {
        cart[productIndex].quantity += 1;
    } else {
        var product = listPro.find(item => item.id === id)
        cart.push({id: id, name: product.name, price: product.price, quantity: 1 });
    }

    localStorage.setItem('cart', JSON.stringify(cart));
    alert(`${productName} đã được thêm vào giỏ hàng!`);
    updateCartDisplay();
}

// Hiển thị giỏ hàng
function updateCartDisplay() {
    const cart = JSON.parse(localStorage.getItem('cart')) || [];
    console.log("Cập nhật hiển thị giỏ hàng:", cart);

    const cartContainer = document.getElementById("cart-display");
    cartContainer.innerHTML = ""; // Xóa nội dung cũ

    cart.forEach(item => {
        const cartItem = document.createElement("div");
        cartItem.classList.add("cart-item");
        cartItem.textContent = `${item.name} - ${item.quantity} x ${item.price} VND`;
        cartContainer.appendChild(cartItem);
    });

    const totalQuantity = cart.reduce((total, item) => total + item.quantity, 0);
    document.getElementById("cart-count").textContent = `(${totalQuantity})`;
}