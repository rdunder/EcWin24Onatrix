document.addEventListener("DOMContentLoaded", e => {
    const mobileMenuBtn = document.getElementById("mobile-menu-togle");
    mobileMenuBtn.addEventListener("click", e => {
        const navigation = document.getElementById("main-header-nav")
        navigation.classList.toggle("show")
    })
})